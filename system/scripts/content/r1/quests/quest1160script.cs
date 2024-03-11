//--- Melia Script -----------------------------------------------------------
// Looking Through [Cataphract Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cataphract Submaster.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(1160)]
public class Quest1160Script : QuestScript
{
	protected override void Load()
	{
		SetId(1160);
		SetName("Looking Through [Cataphract Advancement]");
		SetDescription("Talk to the Cataphract Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PALADIN3_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Sparnasman", new KillObjective(1, MonsterId.Boss_Sparnanman_J1));

		AddDialogHook("MASTER_CATAPHRACT", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CATAPHRACT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CATAPHRACT3_1_select1", "JOB_CATAPHRACT3_1", "I will show you my skills", "I will get it again later"))
		{
			case 1:
				await dialog.Msg("JOB_CATAPHRACT3_1_agree1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_CATAPHRACT3_1_succ1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "If you don't have a Velheider, you can adopt one for free at the Companion Trader!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

