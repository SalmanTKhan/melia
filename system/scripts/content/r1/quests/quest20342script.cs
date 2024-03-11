//--- Melia Script -----------------------------------------------------------
// Adapting to Circumstances (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20342)]
public class Quest20342Script : QuestScript
{
	protected override void Load()
	{
		SetId(20342);
		SetName("Adapting to Circumstances (2)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ01"));

		AddObjective("collect0", "Collect 8 Naktis' Servant's Cloth Scrap(s)", new CollectItemObjective("CHATHEDRAL56_MQ02_1_ITEM", 8));
		AddDrop("CHATHEDRAL56_MQ02_1_ITEM", 10f, 57371, 57370, 57639);

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_MQ_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_MQ_BISHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_MQ02_1_select01", "CHATHEDRAL56_MQ02_1", "I'll go there", "Decline"))
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

		if (character.Inventory.HasItem("CHATHEDRAL56_MQ02_1_ITEM", 8))
		{
			character.Inventory.RemoveItem("CHATHEDRAL56_MQ02_1_ITEM", 8);
			await dialog.Msg("CHATHEDRAL56_MQ02_1_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

