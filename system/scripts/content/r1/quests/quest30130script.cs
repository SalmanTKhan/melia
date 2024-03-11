//--- Melia Script -----------------------------------------------------------
// The Research at Alemeth Forest
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

[QuestScript(30130)]
public class Quest30130Script : QuestScript
{
	protected override void Load()
	{
		SetId(30130);
		SetName("The Research at Alemeth Forest");
		SetDescription("Talk with Gatre");

		AddPrerequisite(new LevelPrerequisite(220));

		AddObjective("collect0", "Collect 15 Research Materials(s)", new CollectItemObjective("ORCHARD_34_1_SQ_1_ITEM", 15));
		AddDrop("ORCHARD_34_1_SQ_1_ITEM", 10f, 57453, 58028, 401445);

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

		switch (await dialog.Select("ORCHARD_34_1_SQ_1_select", "ORCHARD_34_1_SQ_1", "Alright, I'll help you", "Cheer up"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_1_agree");
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

		if (character.Inventory.HasItem("ORCHARD_34_1_SQ_1_ITEM", 15))
		{
			character.Inventory.RemoveItem("ORCHARD_34_1_SQ_1_ITEM", 15);
			await dialog.Msg("ORCHARD_34_1_SQ_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

