//--- Melia Script -----------------------------------------------------------
// Insatiable Hunger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Liliya.
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

[QuestScript(19440)]
public class Quest19440Script : QuestScript
{
	protected override void Load()
	{
		SetId(19440);
		SetName("Insatiable Hunger (1)");
		SetDescription("Talk to Pilgrim Liliya");

		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("collect0", "Collect 6 Lump of Kepo Meat(s)", new CollectItemObjective("PILGRIM46_ITEM_01", 6));
		AddDrop("PILGRIM46_ITEM_01", 10f, "Kepo");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM46_SQ_010_ST", "PILGRIM46_SQ_010", "Ask her what kind of food she wants", "I'm busy"))
		{
			case 1:
				await dialog.Msg("PILGRIM46_SQ_010_AC");
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

		if (character.Inventory.HasItem("PILGRIM46_ITEM_01", 6))
		{
			character.Inventory.RemoveItem("PILGRIM46_ITEM_01", 6);
			await dialog.Msg("NPCAin/PILGRIM46_NPC01/STD/0");
			await dialog.Msg("PILGRIM46_SQ_010_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

