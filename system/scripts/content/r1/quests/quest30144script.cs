//--- Melia Script -----------------------------------------------------------
// The Rune Caster and the Rune Stone [Rune Caster Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Rune Caster Master.
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

[QuestScript(30144)]
public class Quest30144Script : QuestScript
{
	protected override void Load()
	{
		SetId(30144);
		SetName("The Rune Caster and the Rune Stone [Rune Caster Advancement]");
		SetDescription("Talk with the Rune Caster Master");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("collect0", "Collect 30 Malstatue's Magic Fragment(s)", new CollectItemObjective("JOB_RUNECASTER_6_1_ITEM_2", 30));
		AddObjective("collect1", "Collect 15 Velaphid's Cold Blood(s)", new CollectItemObjective("JOB_RUNECASTER_6_1_ITEM_3", 15));
		AddObjective("collect2", "Collect 5 Pumpleflap's Robust Horn(s)", new CollectItemObjective("JOB_RUNECASTER_6_1_ITEM_4", 5));
		AddDrop("JOB_RUNECASTER_6_1_ITEM_2", 10f, "Malstatue");
		AddDrop("JOB_RUNECASTER_6_1_ITEM_3", 10f, "velaphid_red");
		AddDrop("JOB_RUNECASTER_6_1_ITEM_4", 10f, "pumpflap");

		AddDialogHook("RUNECASTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("RUNECASTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RUNECASTER_6_1_select", "JOB_RUNECASTER_6_1", "Ask what the materials are", "Give me some time"))
		{
			case 1:
				await dialog.Msg("JOB_RUNECASTER_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_RUNECASTER_6_1_ITEM_2", 30) && character.Inventory.HasItem("JOB_RUNECASTER_6_1_ITEM_3", 15) && character.Inventory.HasItem("JOB_RUNECASTER_6_1_ITEM_4", 5))
		{
			character.Inventory.RemoveItem("JOB_RUNECASTER_6_1_ITEM_2", 30);
			character.Inventory.RemoveItem("JOB_RUNECASTER_6_1_ITEM_3", 15);
			character.Inventory.RemoveItem("JOB_RUNECASTER_6_1_ITEM_4", 5);
			await dialog.Msg("JOB_RUNECASTER_6_1_succ1");
			// Func/SCR_JOB_RUNECASTER_6_1_SUCC_RUN;
			await dialog.Msg("JOB_RUNECASTER_6_1_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

