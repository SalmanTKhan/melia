//--- Melia Script -----------------------------------------------------------
// Forces Who Occupied the Paupys Crossing (3)
//--- Description -----------------------------------------------------------
// Quest to Defeat the demons in Paslaptis Hideout and get the Symbol of Superior.
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

[QuestScript(91049)]
public class Quest91049Script : QuestScript
{
	protected override void Load()
	{
		SetId(91049);
		SetName("Forces Who Occupied the Paupys Crossing (3)");
		SetDescription("Defeat the demons in Paslaptis Hideout and get the Symbol of Superior");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_02"));

		AddObjective("collect0", "Collect 10 Demon God Ragana's Token(s)", new CollectItemObjective("EP13_F_SIAULIAI_3_MQ_03_ITEM_01", 10));
		AddDrop("EP13_F_SIAULIAI_3_MQ_03_ITEM_01", 5f, "vynmedis");

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28148));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("EP13_F_SIAULIAI_3_MQ_03_ITEM_01", 10))
		{
			character.Inventory.RemoveItem("EP13_F_SIAULIAI_3_MQ_03_ITEM_01", 10);
			await dialog.Msg("EP13_F_SIAULIAI_3_MQ_03_DLG2");
			dialog.UnHideNPC("EP13_F_SIAULIAI_3_MQ_LADA_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

