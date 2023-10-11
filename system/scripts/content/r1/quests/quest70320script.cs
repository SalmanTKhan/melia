//--- Melia Script -----------------------------------------------------------
// My Boundaries [Peltasta Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Peltasta Submaster.
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

[QuestScript(70320)]
public class Quest70320Script : QuestScript
{
	protected override void Load()
	{
		SetId(70320);
		SetName("My Boundaries [Peltasta Advancement]");
		SetDescription("Talk with Peltasta Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_PELTASTA4_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(1, MonsterId.Boss_Chapparition_J1));

		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PELTASTA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PELTASTA4_1_1", "JOB_2_PELTASTA4", "I am requesting to you", "I am quitting on this"))
		{
			case 1:
				await dialog.Msg("JOB_2_PELTASTA4_1_2");
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


		return HookResult.Break;
	}
}

