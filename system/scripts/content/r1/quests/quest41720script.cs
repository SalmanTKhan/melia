//--- Melia Script -----------------------------------------------------------
// Material for Compiling A Scripture (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Giedra.
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

[QuestScript(41720)]
public class Quest41720Script : QuestScript
{
	protected override void Load()
	{
		SetId(41720);
		SetName("Material for Compiling A Scripture (1)");
		SetDescription("Talk to Giedra");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("collect0", "Collect 17 Kepari Inner Shell(s)", new CollectItemObjective("PILGRIM_49_SQ_030_ITEM_1", 17));
		AddDrop("PILGRIM_49_SQ_030_ITEM_1", 10f, "Sec_Kepari_mage");

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_GIEDRA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_GIEDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_030_ST", "PILGRIM_49_SQ_030", "Sure, I'll help", "I will reject on it"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_030_AC");
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

		if (character.Inventory.HasItem("PILGRIM_49_SQ_030_ITEM_1", 17))
		{
			character.Inventory.RemoveItem("PILGRIM_49_SQ_030_ITEM_1", 17);
			await dialog.Msg("PILGRIM_49_SQ_030_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

