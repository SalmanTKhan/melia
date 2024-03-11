//--- Melia Script -----------------------------------------------------------
// Wandering Spirits (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Quiet Owl Sculpture.
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

[QuestScript(90067)]
public class Quest90067Script : QuestScript
{
	protected override void Load()
	{
		SetId(90067);
		SetName("Wandering Spirits (1)");
		SetDescription("Talk to Quiet Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_1"));

		AddObjective("collect0", "Collect 8 Blue Sakmoli Leaves(s)", new CollectItemObjective("KATYN_45_3_SQ_13_ITEM", 8));
		AddDrop("KATYN_45_3_SQ_13_ITEM", 10f, "Sakmoli_purple");

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_OWL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_OWL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_13_ST", "KATYN_45_3_SQ_13", "I'll help you", "I don't have time for that now"))
		{
			case 1:
				await dialog.Msg("KATYN_45_3_SQ_13_AG");
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

		if (character.Inventory.HasItem("KATYN_45_3_SQ_13_ITEM", 8))
		{
			character.Inventory.RemoveItem("KATYN_45_3_SQ_13_ITEM", 8);
			await dialog.Msg("KATYN_45_3_SQ_13_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

