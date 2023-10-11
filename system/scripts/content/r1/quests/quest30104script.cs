//--- Melia Script -----------------------------------------------------------
// Mage Tower in Chaos [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Thaumaturge Submaster.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(30104)]
public class Quest30104Script : QuestScript
{
	protected override void Load()
	{
		SetId(30104);
		SetName("Mage Tower in Chaos [Thaumaturge Advancement]");
		SetDescription("Talk to the Thaumaturge Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUMATURGE4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Salamander", new KillObjective(1, MonsterId.Boss_Salamander_J1));

		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_THAUMATURGE_5_1_select", "JOB_2_THAUMATURGE_5_1", "Ask what you should do", "It's best to face it"))
		{
			case 1:
				await dialog.Msg("JOB_2_THAUMATURGE_5_1_agree");
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

		await dialog.Msg("JOB_2_THAUMATURGE_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

