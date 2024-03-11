//--- Melia Script -----------------------------------------------------------
// The Third Epitaph (1)
//--- Description -----------------------------------------------------------
// Quest to Look at the tombstone in the Nevieda Altar Area.
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

[QuestScript(40630)]
public class Quest40630Script : QuestScript
{
	protected override void Load()
	{
		SetId(40630);
		SetName("The Third Epitaph (1)");
		SetDescription("Look at the tombstone in the Nevieda Altar Area");

		AddPrerequisite(new LevelPrerequisite(172));

		AddObjective("collect0", "Collect 15 Gooey Oil(s)", new CollectItemObjective("REMAINS37_2_SQ_050_ITEM_2", 15));
		AddDrop("REMAINS37_2_SQ_050_ITEM_2", 10f, 57627, 41302, 57615);

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_VINE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_VINE", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_2_SQ_060");
	}
}

