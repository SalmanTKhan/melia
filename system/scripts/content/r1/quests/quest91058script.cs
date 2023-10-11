//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91058)]
public class Quest91058Script : QuestScript
{
	protected override void Load()
	{
		SetId(91058);
		SetName("Secrets Hidden Underground (3)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_2"));

		AddObjective("collect0", "Collect 10 Mokslas' Research Data(s)", new CollectItemObjective("EP13_2_DPRISON2_MQ_ITEM_1", 10));
		AddDrop("EP13_2_DPRISON2_MQ_ITEM_1", 7f, 59659, 59660, 59661);

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_3_DLG1", "EP13_2_DPRISON2_MQ_3", "We should hurry", "Let's rest for a while"))
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

		if (character.Inventory.HasItem("EP13_2_DPRISON2_MQ_ITEM_1", 10))
		{
			character.Inventory.RemoveItem("EP13_2_DPRISON2_MQ_ITEM_1", 10);
			await dialog.Msg("EP13_2_DPRISON2_MQ_3_DLG3");
			dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

