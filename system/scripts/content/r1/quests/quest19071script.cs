//--- Melia Script -----------------------------------------------------------
// Failure and Success
//--- Description -----------------------------------------------------------
// Quest to Talk to Equipment Merchant in Fedimian.
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

[QuestScript(19071)]
public class Quest19071Script : QuestScript
{
	protected override void Load()
	{
		SetId(19071);
		SetName("Failure and Success");
		SetDescription("Talk to Equipment Merchant in Fedimian");

		AddPrerequisite(new LevelPrerequisite(121));
		// Required quest doesn't exist anymore, so disabling requirement.
/**		AddPrerequisite(new CompletedPrerequisite("FEDIMIAN_HQ_01_1"));
		**/

		AddObjective("collect0", "Collect 30 Mark of a Pilgrim(s)", new CollectItemObjective("FEDIMIAN_HQ_01_ITEM1", 30));
		AddDrop("FEDIMIAN_HQ_01_ITEM1", 2f, 41449, 57404, 57402, 41291);

		AddDialogHook("FED_EQUIP", "BeforeStart", BeforeStart);
		AddDialogHook("FED_EQUIP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FEDIMIAN_HQ_01_ST", "FEDIMIAN_HQ_01", "I'll help", "Cancel"))
		{
			case 1:
				await dialog.Msg("FEDIMIAN_HQ_01_AC");
				// Func/REINFORCE_SESSION_DESTROY;
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

		if (character.Inventory.HasItem("FEDIMIAN_HQ_01_ITEM1", 30))
		{
			character.Inventory.RemoveItem("FEDIMIAN_HQ_01_ITEM1", 30);
			await dialog.Msg("FEDIMIAN_HQ_01_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

