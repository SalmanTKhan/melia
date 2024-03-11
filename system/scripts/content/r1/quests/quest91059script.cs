//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (4)
//--- Description -----------------------------------------------------------
// Quest to Find Paulius.
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

[QuestScript(91059)]
public class Quest91059Script : QuestScript
{
	protected override void Load()
	{
		SetId(91059);
		SetName("Secrets Hidden Underground (4)");
		SetDescription("Find Paulius");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_3"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_4_DLG1", "EP13_2_DPRISON2_MQ_4", "I will investigate it.", "I'll work on other things first"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_4");
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

		if (character.Inventory.HasItem("EP13_2_DPRISON2_MQ_ITEM_2", 1))
		{
			character.Inventory.RemoveItem("EP13_2_DPRISON2_MQ_ITEM_2", 1);
			await dialog.Msg("EP13_2_DPRISON2_MQ_4_DLG2");
			await dialog.Msg("EP13_2_DPRISON2_MQ_4_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

