//--- Melia Script -----------------------------------------------------------
// True Nature of the Research (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Sarma.
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

[QuestScript(30133)]
public class Quest30133Script : QuestScript
{
	protected override void Load()
	{
		SetId(30133);
		SetName("True Nature of the Research (1)");
		SetDescription("Talk with Sarma");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_3"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_4_select", "ORCHARD_34_1_SQ_4", "Act as if you are helping", "I don't want to engage in a dangerous task"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_4_agree");
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

		if (character.Inventory.HasItem("ORCHARD_34_1_SQ_4_ITEM_2", 5))
		{
			character.Inventory.RemoveItem("ORCHARD_34_1_SQ_4_ITEM_2", 5);
			await dialog.Msg("ORCHARD_34_1_SQ_4_succ");
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("ORCHARD_34_1_SQ_NPC_2_1");
			dialog.UnHideNPC("ORCHARD_34_1_SQ_NPC_2_2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

