//--- Melia Script -----------------------------------------------------------
// A Stronger Antidote(2)
//--- Description -----------------------------------------------------------
// Quest to Defeat the Green Rafflesia to obtain Sticky Sap Rafflesia.
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

[QuestScript(30213)]
public class Quest30213Script : QuestScript
{
	protected override void Load()
	{
		SetId(30213);
		SetName("A Stronger Antidote(2)");
		SetDescription("Defeat the Green Rafflesia to obtain Sticky Sap Rafflesia");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_8"));

		AddObjective("collect0", "Collect 14 Sticky Rafflesia Sap(s)", new CollectItemObjective("ORCHARD_34_3_SQ_ITEM7", 14));
		AddDrop("ORCHARD_34_3_SQ_ITEM7", 10f, "rafflesia_green");

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ORCHARD_34_3_SQ_ITEM7", 14))
		{
			character.Inventory.RemoveItem("ORCHARD_34_3_SQ_ITEM7", 14);
			await dialog.Msg("ORCHARD_34_3_SQ_9_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

