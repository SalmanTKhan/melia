//--- Melia Script -----------------------------------------------------------
// Swore to Protect (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Yulia.
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

[QuestScript(80432)]
public class Quest80432Script : QuestScript
{
	protected override void Load()
	{
		SetId(80432);
		SetName("Swore to Protect (6)");
		SetDescription("Talk to Kupole Yulia");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_05"));

		AddObjective("collect0", "Collect 10 Red Banterer Essence(s)", new CollectItemObjective("F_MAPLE_242_MQ_06_ITEM", 10));
		AddDrop("F_MAPLE_242_MQ_06_ITEM", 10f, "banterer_red");

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23655));

		AddDialogHook("F_MAPLE_242_MQ_06_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_06_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_06_ST", "F_MAPLE_24_2_MQ_06", "I'll go find it.", "What do you mean, I don't sense any energy."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_2_MQ_06_AFST");
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

		if (character.Inventory.HasItem("F_MAPLE_242_MQ_06_ITEM", 10))
		{
			character.Inventory.RemoveItem("F_MAPLE_242_MQ_06_ITEM", 10);
			await dialog.Msg("F_MAPLE_24_2_MQ_06_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

