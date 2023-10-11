//--- Melia Script -----------------------------------------------------------
// Troop Left Alone
//--- Description -----------------------------------------------------------
// Quest to Look for Squad Commander Johan.
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

[QuestScript(8258)]
public class Quest8258Script : QuestScript
{
	protected override void Load()
	{
		SetId(8258);
		SetName("Troop Left Alone");
		SetDescription("Look for Squad Commander Johan");

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_12"));

		AddObjective("collect0", "Collect 8 Bloodstained Report Page(s)", new CollectItemObjective("KATYN14_MQ_16_ITEM", 8));
		AddDrop("KATYN14_MQ_16_ITEM", 10f, 400302, 400281, 400344, 400462);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_JOHN", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_JOHN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_17_01", "KATYN14_MQ_17", "Find the report", "Better return quickly"))
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

		if (character.Inventory.HasItem("KATYN14_MQ_16_ITEM", 8))
		{
			character.Inventory.RemoveItem("KATYN14_MQ_16_ITEM", 8);
			await dialog.Msg("KATYN14_MQ_17_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

