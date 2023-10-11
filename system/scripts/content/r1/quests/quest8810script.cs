//--- Melia Script -----------------------------------------------------------
// White Lie (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Benjaminas.
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

[QuestScript(8810)]
public class Quest8810Script : QuestScript
{
	protected override void Load()
	{
		SetId(8810);
		SetName("White Lie (1)");
		SetDescription("Talk to Grave Robber Benjaminas");

		AddPrerequisite(new LevelPrerequisite(184));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_10"));

		AddObjective("collect0", "Collect 10 Scent Stone Powder(s)", new CollectItemObjective("FLASH59_SQ_11_ITEM", 10));
		AddDrop("FLASH59_SQ_11_ITEM", 10f, 400063, 47462, 57632);

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_BENJAMINAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_BENJAMINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_11_01", "FLASH59_SQ_11", "I will collect it", "Tell him that you can't help"))
		{
			case 1:
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

		if (character.Inventory.HasItem("FLASH59_SQ_11_ITEM", 10))
		{
			character.Inventory.RemoveItem("FLASH59_SQ_11_ITEM", 10);
			await dialog.Msg("FLASH59_SQ_11_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

