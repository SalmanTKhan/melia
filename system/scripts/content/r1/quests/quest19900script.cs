//--- Melia Script -----------------------------------------------------------
// Avoiding Infatuation (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Theophilis.
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

[QuestScript(19900)]
public class Quest19900Script : QuestScript
{
	protected override void Load()
	{
		SetId(19900);
		SetName("Avoiding Infatuation (3)");
		SetDescription("Talk to Pilgrim Theophilis");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_020"));

		AddDialogHook("PILGRIM52_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_040_ST", "PILGRIM52_SQ_040", "I can help you", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM52_SQ_040_AC");
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

		if (character.Inventory.HasItem("PILGRIM52_ITEM_05", 1) && character.Inventory.HasItem("PILGRIM52_ITEM_06", 1))
		{
			character.Inventory.RemoveItem("PILGRIM52_ITEM_05", 1);
			character.Inventory.RemoveItem("PILGRIM52_ITEM_06", 1);
			await dialog.Msg("PILGRIM52_SQ_040_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM52_SQ_050");
	}
}

