//--- Melia Script -----------------------------------------------------------
// The Ramparts More Durable Than the Kingdom (1)
//--- Description -----------------------------------------------------------
// Quest to Make rubbings.
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

[QuestScript(40501)]
public class Quest40501Script : QuestScript
{
	protected override void Load()
	{
		SetId(40501);
		SetName("The Ramparts More Durable Than the Kingdom (1)");
		SetDescription("Make rubbings");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_020"));
		AddPrerequisite(new ItemPrerequisite("REMAINS37_1_SQ_010_ITEM_1", 1));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("REMAINS37_1_MT02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS37_1_SQ_021_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

