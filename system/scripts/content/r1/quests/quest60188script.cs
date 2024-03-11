//--- Melia Script -----------------------------------------------------------
// Kedora Merchant Alliance Applicant
//--- Description -----------------------------------------------------------
// Quest to Talk to Tomalov.
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

[QuestScript(60188)]
public class Quest60188Script : QuestScript
{
	protected override void Load()
	{
		SetId(60188);
		SetName("Kedora Merchant Alliance Applicant");
		SetDescription("Talk to Tomalov");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("collect0", "Collect 10 Sticky Wings(s)", new CollectItemObjective("PILGRIM49_RP_1_ITEM", 10));
		AddDrop("PILGRIM49_RP_1_ITEM", 9f, 58133, 58132);

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM49_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM49_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM49_RP_1_1", "PILGRIM49_RP_1", "I'll help you", "Ignore"))
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

		if (character.Inventory.HasItem("PILGRIM49_RP_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("PILGRIM49_RP_1_ITEM", 10);
			await dialog.Msg("PILGRIM49_RP_1_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

