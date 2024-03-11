//--- Melia Script -----------------------------------------------------------
// Endless Gluttony (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Julius.
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

[QuestScript(19470)]
public class Quest19470Script : QuestScript
{
	protected override void Load()
	{
		SetId(19470);
		SetName("Endless Gluttony (1)");
		SetDescription("Talk to Pilgrim Julius");

		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("collect0", "Collect 4 Kepari Flesh(s)", new CollectItemObjective("PILGRIM46_ITEM_05", 4));
		AddDrop("PILGRIM46_ITEM_05", 10f, "Kepari");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_040_ST", "PILGRIM46_SQ_040", "I will get you some meat from the monsters", "Ignore it and go your way"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_040_AC");
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

		if (character.Inventory.HasItem("PILGRIM46_ITEM_05", 4))
		{
			character.Inventory.RemoveItem("PILGRIM46_ITEM_05", 4);
			await dialog.Msg("PILGRIM46_SQ_040_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

