//--- Melia Script -----------------------------------------------------------
// Legal Profit
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Hubertas.
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

[QuestScript(8806)]
public class Quest8806Script : QuestScript
{
	protected override void Load()
	{
		SetId(8806);
		SetName("Legal Profit");
		SetDescription("Talk to Grave Robber Hubertas");

		AddPrerequisite(new LevelPrerequisite(184));

		AddObjective("collect0", "Collect 10 Rambear Claws(s)", new CollectItemObjective("FLASH59_SQ_07_ITEM", 10));
		AddDrop("FLASH59_SQ_07_ITEM", 10f, "Rambear");

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_HUBERTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_HUBERTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_07_01", "FLASH59_SQ_07", "I will collect for her", "Decline"))
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

		if (character.Inventory.HasItem("FLASH59_SQ_07_ITEM", 10))
		{
			character.Inventory.RemoveItem("FLASH59_SQ_07_ITEM", 10);
			await dialog.Msg("FLASH59_SQ_07_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}
