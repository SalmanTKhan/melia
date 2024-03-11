//--- Melia Script -----------------------------------------------------------
// The Parts Thief
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Gilbert.
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

[QuestScript(17110)]
public class Quest17110Script : QuestScript
{
	protected override void Load()
	{
		SetId(17110);
		SetName("The Parts Thief");
		SetDescription("Talk to Watcher Gilbert");

		AddPrerequisite(new LevelPrerequisite(26));

		AddObjective("collect0", "Collect 8 Gear(s)", new CollectItemObjective("GELE571_MQ_02_ITEM", 8));
		AddDrop("GELE571_MQ_02_ITEM", 8f, "Npanto_baby");

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_GILBERT", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_GILBERT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_MQ_02_01", "GELE571_MQ_02", "I'll get it to you", "About repairing the cable car", "I don't want to"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE571_MQ_02_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("GELE571_MQ_02_ITEM", 8))
		{
			character.Inventory.RemoveItem("GELE571_MQ_02_ITEM", 8);
			await dialog.Msg("GELE571_MQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

