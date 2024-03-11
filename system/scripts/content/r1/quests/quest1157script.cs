//--- Melia Script -----------------------------------------------------------
// The Way to Become A Wizard [Elementalist]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elementalist Submaster.
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

[QuestScript(1157)]
public class Quest1157Script : QuestScript
{
	protected override void Load()
	{
		SetId(1157);
		SetName("The Way to Become A Wizard [Elementalist]");
		SetDescription("Talk to the Elementalist Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("collect0", "Collect 10 Varb Resin(s)", new CollectItemObjective("JOB_WARLOCK3_1_ITEM1", 10));
		AddObjective("collect1", "Collect 5 Zinutekas Tail Fragment(s)", new CollectItemObjective("JOB_WARLOCK3_1_ITEM2", 5));
		AddObjective("collect2", "Collect 3 Boowook Activation Core(s)", new CollectItemObjective("JOB_WARLOCK3_1_ITEM3", 3));
		AddDrop("JOB_WARLOCK3_1_ITEM1", 10f, "varv");
		AddDrop("JOB_WARLOCK3_1_ITEM2", 5f, "zinutekas");
		AddDrop("JOB_WARLOCK3_1_ITEM3", 3f, "Moving_trap");

		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARLOCK3_1_select1", "JOB_WARLOCK3_1", "I'll take on the assignment", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_WARLOCK3_1_agree1");
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

		if (character.Inventory.HasItem("JOB_WARLOCK3_1_ITEM1", 10) && character.Inventory.HasItem("JOB_WARLOCK3_1_ITEM2", 5) && character.Inventory.HasItem("JOB_WARLOCK3_1_ITEM3", 3))
		{
			character.Inventory.RemoveItem("JOB_WARLOCK3_1_ITEM1", 10);
			character.Inventory.RemoveItem("JOB_WARLOCK3_1_ITEM2", 5);
			character.Inventory.RemoveItem("JOB_WARLOCK3_1_ITEM3", 3);
			await dialog.Msg("JOB_WARLOCK3_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

