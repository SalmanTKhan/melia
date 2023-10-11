//--- Melia Script -----------------------------------------------------------
// How to Eat a Kepa (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40510)]
public class Quest40510Script : QuestScript
{
	protected override void Load()
	{
		SetId(40510);
		SetName("How to Eat a Kepa (1)");
		SetDescription("Talk to Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_025"));

		AddObjective("collect0", "Collect 4 Acidic Body Fluid(s)", new CollectItemObjective("REMAINS37_1_SQ_030_ITEM_2", 4));
		AddDrop("REMAINS37_1_SQ_030_ITEM_2", 10f, 57620, 57622, 57596);

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_030_ST", "REMAINS37_1_SQ_030", "I'll get it. ", "About the work you are doing here", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("REMAINS37_1_SQ_030_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAINS37_1_SQ_030_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAINS37_1_SQ_030_ITEM_2", 4))
		{
			character.Inventory.RemoveItem("REMAINS37_1_SQ_030_ITEM_2", 4);
			await dialog.Msg("REMAINS37_1_SQ_030_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_1_SQ_031");
	}
}

