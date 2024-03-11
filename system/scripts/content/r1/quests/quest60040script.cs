//--- Melia Script -----------------------------------------------------------
// Food for Dionys
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60040)]
public class Quest60040Script : QuestScript
{
	protected override void Load()
	{
		SetId(60040);
		SetName("Food for Dionys");
		SetDescription("Talk to Kupole Sigita");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_06"));

		AddObjective("collect0", "Collect 9 Empty Soul(s)", new CollectItemObjective("VPRISON515_SQ_02_ITEM", 9));
		AddDrop("VPRISON515_SQ_02_ITEM", 7.5f, 57720, 400442, 57718);

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON515_SQ_02_01", "VPRISON515_SQ_02", "Yeah, I'll collect them", "He'll be cured soon"))
		{
			case 1:
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

		if (character.Inventory.HasItem("VPRISON515_SQ_02_ITEM", 9))
		{
			character.Inventory.RemoveItem("VPRISON515_SQ_02_ITEM", 9);
			await dialog.Msg("VPRISON515_SQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

