//--- Melia Script -----------------------------------------------------------
// Request for the Secret Rescue (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Gatre.
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

[QuestScript(30132)]
public class Quest30132Script : QuestScript
{
	protected override void Load()
	{
		SetId(30132);
		SetName("Request for the Secret Rescue (2)");
		SetDescription("Talk with Gatre");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_2"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_3_select", "ORCHARD_34_1_SQ_3", "I'll try to find them", "Go alone"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_3_agree");
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

		if (character.Inventory.HasItem("ORCHARD_34_1_SQ_3_ITEM", 1))
		{
			character.Inventory.RemoveItem("ORCHARD_34_1_SQ_3_ITEM", 1);
			await dialog.Msg("ORCHARD_34_1_SQ_3_succ");
			dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_2_1");
			dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_2_2");
			dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_2_3");
			dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_2_4");
			dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_2_5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

