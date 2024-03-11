//--- Melia Script -----------------------------------------------------------
// Weapons Supply (2)
//--- Description -----------------------------------------------------------
// Quest to Collaborate with Horacius.
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

[QuestScript(40380)]
public class Quest40380Script : QuestScript
{
	protected override void Load()
	{
		SetId(40380);
		SetName("Weapons Supply (2)");
		SetDescription("Collaborate with Horacius");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_010"));

		AddObjective("collect0", "Collect 15 Soft Leather(s)", new CollectItemObjective("FARM47_1_SQ_020_ITEM_1", 15));
		AddDrop("FARM47_1_SQ_020_ITEM_1", 10f, 57329, 57328);

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_LEADER", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_LEADER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_020_ST", "FARM47_1_SQ_020", "I will get the leather", "About the magic circles", "I can't help with such task"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_020_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM47_1_SQ_020_ITEM_1", 15))
		{
			character.Inventory.RemoveItem("FARM47_1_SQ_020_ITEM_1", 15);
			await dialog.Msg("FARM47_1_SQ_020_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

