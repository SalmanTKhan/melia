//--- Melia Script -----------------------------------------------------------
// The Irregular Stone Statue
//--- Description -----------------------------------------------------------
// Quest to Talk to Joana.
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

[QuestScript(40320)]
public class Quest40320Script : QuestScript
{
	protected override void Load()
	{
		SetId(40320);
		SetName("The Irregular Stone Statue");
		SetDescription("Talk to Joana");

		AddPrerequisite(new LevelPrerequisite(89));
		AddPrerequisite(new CompletedPrerequisite("FARM47_2_SQ_045"));

		AddObjective("collect0", "Collect 9 Sticky Sap(s)", new CollectItemObjective("FARM47_2_SQ_050_ITEM_1", 9));
		AddDrop("FARM47_2_SQ_050_ITEM_1", 7f, 57327, 57488, 57618, 57645);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_JOANA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JOANA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_2_SQ_050_ST", "FARM47_2_SQ_050", "I'll help you", "About the things that are occurring here", "I have a long way ahead so I will get going now"))
		{
			case 1:
				await dialog.Msg("FARM47_2_SQ_050_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_2_SQ_050_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM47_2_SQ_050_ITEM_1", 9))
		{
			character.Inventory.RemoveItem("FARM47_2_SQ_050_ITEM_1", 9);
			await dialog.Msg("FARM47_2_SQ_050_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

