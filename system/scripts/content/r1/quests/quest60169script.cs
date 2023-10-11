//--- Melia Script -----------------------------------------------------------
// Too Much For One Person
//--- Description -----------------------------------------------------------
// Quest to Talk to the Tired Soldier.
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

[QuestScript(60169)]
public class Quest60169Script : QuestScript
{
	protected override void Load()
	{
		SetId(60169);
		SetName("Too Much For One Person");
		SetDescription("Talk to the Tired Soldier");

		AddPrerequisite(new LevelPrerequisite(78));

		AddObjective("collect0", "Collect 9 Dirty Pouch(s)", new CollectItemObjective("ROKAS31_RP_1_ITEM", 9));
		AddDrop("ROKAS31_RP_1_ITEM", 8.5f, 41441, 401041, 57600);

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_SUB", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_SUB", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_RP_1_1", "ROKAS31_RP_1", "Yeah, I'll collect them", "Do it yourself"))
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

		if (character.Inventory.HasItem("ROKAS31_RP_1_ITEM", 9))
		{
			character.Inventory.RemoveItem("ROKAS31_RP_1_ITEM", 9);
			await dialog.Msg("ROKAS31_RP_1_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

