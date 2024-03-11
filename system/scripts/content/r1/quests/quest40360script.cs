//--- Melia Script -----------------------------------------------------------
// Restoring Willpower! 
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugas.
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

[QuestScript(40360)]
public class Quest40360Script : QuestScript
{
	protected override void Load()
	{
		SetId(40360);
		SetName("Restoring Willpower! ");
		SetDescription("Talk to Jugas");

		AddPrerequisite(new LevelPrerequisite(89));

		AddObjective("collect0", "Collect 1 Sack of Grain", new CollectItemObjective("FARM47_2_SQ_090_ITEM_1", 1));
		AddDrop("FARM47_2_SQ_090_ITEM_1", 1f, 57327, 57488, 57645, 57618);

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_DZIUGAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_DZIUGAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_2_SQ_090_ST", "FARM47_2_SQ_090", "I will find it", "I'm busy"))
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

		if (character.Inventory.HasItem("FARM47_2_SQ_090_ITEM_1", 1))
		{
			character.Inventory.RemoveItem("FARM47_2_SQ_090_ITEM_1", 1);
			await dialog.Msg("FARM47_2_SQ_090_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

