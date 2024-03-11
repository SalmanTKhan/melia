//--- Melia Script -----------------------------------------------------------
// True Nature of the Research (4)
//--- Description -----------------------------------------------------------
// Quest to Collect the leaves of the plants that grew up strangely.
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

[QuestScript(30136)]
public class Quest30136Script : QuestScript
{
	protected override void Load()
	{
		SetId(30136);
		SetName("True Nature of the Research (4)");
		SetDescription("Collect the leaves of the plants that grew up strangely");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_6"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ORCHARD_34_1_SQ_7_ITEM", 8))
		{
			character.Inventory.RemoveItem("ORCHARD_34_1_SQ_7_ITEM", 8);
			await dialog.Msg("ORCHARD_34_1_SQ_7_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

