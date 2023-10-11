//--- Melia Script -----------------------------------------------------------
// Road of the Goddess [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(1159)]
public class Quest1159Script : QuestScript
{
	protected override void Load()
	{
		SetId(1159);
		SetName("Road of the Goddess [Paladin Advancement]");
		SetDescription("Talk to the Paladin Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PALADIN3_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Sparnasman", new KillObjective(1, MonsterId.Boss_Sparnanman_J1));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PALADIN3_1_select1", "JOB_PALADIN3_1", "I will prove it", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PALADIN3_1_agree1");
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

		await dialog.Msg("JOB_PALADIN3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

