//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Danute.
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

[QuestScript(60260)]
public class Quest60260Script : QuestScript
{
	protected override void Load()
	{
		SetId(60260);
		SetName("Necessary Mistake (6)");
		SetDescription("Talk to Kupole Danute");

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_5"));

		AddObjective("collect0", "Collect 15 Demon's Magic Source(s)", new CollectItemObjective("FANTASYLIB483_MQ_6_2_ITEM", 15));
		AddDrop("FANTASYLIB483_MQ_6_2_ITEM", 10f, 58873, 58874, 58875, 58400);

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_DANUTE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_DANUTE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_6_1", "FANTASYLIB483_MQ_6", "I'll help you", "Wait for a while"))
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

		if (character.Inventory.HasItem("FANTASYLIB483_MQ_6_1_ITEM", 7) && character.Inventory.HasItem("FANTASYLIB483_MQ_6_2_ITEM", 15))
		{
			character.Inventory.RemoveItem("FANTASYLIB483_MQ_6_1_ITEM", 7);
			character.Inventory.RemoveItem("FANTASYLIB483_MQ_6_2_ITEM", 15);
			await dialog.Msg("FANTASYLIB483_MQ_6_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

