//--- Melia Script -----------------------------------------------------------
// Support for the Greater Justice (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80070)]
public class Quest80070Script : QuestScript
{
	protected override void Load()
	{
		SetId(80070);
		SetName("Support for the Greater Justice (3)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_5"));

		AddObjective("collect0", "Collect 12 Spion Tree Leaves(s)", new CollectItemObjective("SIAULIAI_35_1_SQ_6_LEAF", 12));
		AddDrop("SIAULIAI_35_1_SQ_6_LEAF", 10f, "Spion_blue");

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_35_1_SQ_6_start", "SIAULIAI_35_1_SQ_6", "Alright, I'll help you", "I am too lazy to do it"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_35_1_SQ_6_agree");
				// Func/SIAULIAI_35_1_SQ_6_HIDE;
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

		if (character.Inventory.HasItem("SIAULIAI_35_1_SQ_6_LEAF", 12))
		{
			character.Inventory.RemoveItem("SIAULIAI_35_1_SQ_6_LEAF", 12);
			await dialog.Msg("SIAULIAI_35_1_SQ_6_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

