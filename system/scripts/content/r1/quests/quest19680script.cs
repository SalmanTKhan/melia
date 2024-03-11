//--- Melia Script -----------------------------------------------------------
// Freedom to the Enraged Souls
//--- Description -----------------------------------------------------------
// Quest to Branginti Hill Altar.
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

[QuestScript(19680)]
public class Quest19680Script : QuestScript
{
	protected override void Load()
	{
		SetId(19680);
		SetName("Freedom to the Enraged Souls");
		SetDescription("Branginti Hill Altar");

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("collect0", "Collect 20 Pilgrim's Lost Scripture Page(s)", new CollectItemObjective("PILGRIM50_ITEM_04", 20));
		AddDrop("PILGRIM50_ITEM_04", 10f, 41450, 57403, 57641, 57604);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("PILGRIM50_ITEM_05", 1));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ANGRY03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_ANGRY03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("PILGRIM50_ITEM_04", 20))
		{
			character.Inventory.RemoveItem("PILGRIM50_ITEM_04", 20);
			// Func/SCR_PILGRIM50_SQ_070_TRACK_PLAY;
			dialog.HideNPC("PILGRIM50_BIBLE");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

