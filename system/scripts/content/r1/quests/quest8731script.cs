//--- Melia Script -----------------------------------------------------------
// Aim [Archer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Archer Master.
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

[QuestScript(8731)]
public class Quest8731Script : QuestScript
{
	protected override void Load()
	{
		SetId(8731);
		SetName("Aim [Archer Advancement]");
		SetDescription("Call of the Archer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_ARCHER5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Sparnashorn", new KillObjective(1, MonsterId.Boss_Sparnashorn_J1));

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ARCHER5_1_01", "JOB_ARCHER5_1", "I'll accept the test", "Decline"))
		{
			case 1:
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

		await dialog.Msg("JOB_ARCHER5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

