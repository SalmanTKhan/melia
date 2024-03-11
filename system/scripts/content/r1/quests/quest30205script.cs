//--- Melia Script -----------------------------------------------------------
// Barha Forest's Antidote(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Adas.
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

[QuestScript(30205)]
public class Quest30205Script : QuestScript
{
	protected override void Load()
	{
		SetId(30205);
		SetName("Barha Forest's Antidote(1)");
		SetDescription("Talk to Researcher Adas");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_12"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_1_select", "ORCHARD_34_3_SQ_1", "Say that you are pursuing Sarma as a favor to Gatre", "Say that you are too busy to talk"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_1_agree");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_OBJ_7");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_OBJ_9");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_OBJ_10");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_NPC_1");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_NPC_2");
				dialog.UnHideNPC("ORCHARD_34_3_SQ_NPC_3");
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

		if (character.Inventory.HasItem("ORCHARD_34_3_SQ_ITEM1", 7))
		{
			character.Inventory.RemoveItem("ORCHARD_34_3_SQ_ITEM1", 7);
			await dialog.Msg("ORCHARD_34_3_SQ_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

