//--- Melia Script -----------------------------------------------------------
// Great Success or Great Failure (3)
//--- Description -----------------------------------------------------------
// Quest to Look for Lucienne Winterspoon with the ownerless cultivated land.
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

[QuestScript(80074)]
public class Quest80074Script : QuestScript
{
	protected override void Load()
	{
		SetId(80074);
		SetName("Great Success or Great Failure (3)");
		SetDescription("Look for Lucienne Winterspoon with the ownerless cultivated land");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_35_1_SQ_10_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_9"));

		AddObjective("kill0", "Kill 1 Wild Carnivore", new KillObjective(1, MonsterId.Boss_Carnivore_Q2));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 72252));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_35_1_SQ_10_succ");
		// Func/SIAULIAI_35_1_SQ_10_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

