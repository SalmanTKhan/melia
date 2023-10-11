//--- Melia Script -----------------------------------------------------------
// The Alchemist of Nahash Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Look for the owners of reagent bottles from Nahash Forest .
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

[QuestScript(80066)]
public class Quest80066Script : QuestScript
{
	protected override void Load()
	{
		SetId(80066);
		SetName("The Alchemist of Nahash Forest (2)");
		SetDescription("Look for the owners of reagent bottles from Nahash Forest ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_35_1_SQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_1"));

		AddObjective("kill0", "Kill 6 Blue Spion(s) or Blue Spion Archer(s) or Blue Spion Mage(s)", new KillObjective(6, 57910, 57912, 57913));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_35_1_SQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

