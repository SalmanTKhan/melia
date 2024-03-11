//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vakarine.
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

[QuestScript(60024)]
public class Quest60024Script : QuestScript
{
	protected override void Load()
	{
		SetId(60024);
		SetName("The Dimensional Crack (2)");
		SetDescription("Talk to Goddess Vakarine");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_01"));

		AddObjective("collect0", "Collect 4 Trace of Transference(s)", new CollectItemObjective("VPRISON515_MQ_RUNE_EMPTY_ITEM", 4));
		AddDrop("VPRISON515_MQ_RUNE_EMPTY_ITEM", 10f, 57720, 400442, 57718);

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("VPRISON515_MQ_RUNE_ITEM", 1));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON515_MQ_02_01", "VPRISON515_MQ_02", "I will collect the Traces of Transference", "I will prepare a little more"))
		{
			case 1:
				await dialog.Msg("VPRISON515_MQ_02_AG");
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

		if (character.Inventory.HasItem("VPRISON515_MQ_RUNE_EMPTY_ITEM", 4))
		{
			character.Inventory.RemoveItem("VPRISON515_MQ_RUNE_EMPTY_ITEM", 4);
			await dialog.Msg("VPRISON515_MQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

