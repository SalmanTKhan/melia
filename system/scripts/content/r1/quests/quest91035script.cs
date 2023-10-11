//--- Melia Script -----------------------------------------------------------
// Initiate the Investigation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91035)]
public class Quest91035Script : QuestScript
{
	protected override void Load()
	{
		SetId(91035);
		SetName("Initiate the Investigation (1)");
		SetDescription("Talk to the Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_02"));

		AddObjective("collect0", "Collect 1 Unidentified Ore", new CollectItemObjective("EP13_F_SIAULIAI_1_MQ_03_ITEM_01", 1));
		AddDrop("EP13_F_SIAULIAI_1_MQ_03_ITEM_01", 5f, 59577, 59576, 59578, 59579);

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 14));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_03_DLG1", "EP13_F_SIAULIAI_1_MQ_03", "I'll go there", "I need more time"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_1_MQ_03_DLG2");
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

		if (character.Inventory.HasItem("EP13_F_SIAULIAI_1_MQ_03_ITEM_01", 1))
		{
			character.Inventory.RemoveItem("EP13_F_SIAULIAI_1_MQ_03_ITEM_01", 1);
			await dialog.Msg("EP13_F_SIAULIAI_1_MQ_03_DLG4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

