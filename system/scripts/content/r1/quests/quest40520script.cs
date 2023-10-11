//--- Melia Script -----------------------------------------------------------
// Born with a Silver Spoon (1)
//--- Description -----------------------------------------------------------
// Quest to Ask Adrijus.
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

[QuestScript(40520)]
public class Quest40520Script : QuestScript
{
	protected override void Load()
	{
		SetId(40520);
		SetName("Born with a Silver Spoon (1)");
		SetDescription("Ask Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_031"));

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

		switch (await dialog.Select("REMAINS37_1_SQ_040_ST", "REMAINS37_1_SQ_040", "I'll get it. ", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_1_SQ_040_AC");
				dialog.HideNPC("REMAINS37_1_ADRIJUS");
				await dialog.Msg("FadeOutIN/2500");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAINS37_1_SQ_040_ITEM_2", 3))
		{
			character.Inventory.RemoveItem("REMAINS37_1_SQ_040_ITEM_2", 3);
			await dialog.Msg("REMAINS37_1_SQ_040_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

