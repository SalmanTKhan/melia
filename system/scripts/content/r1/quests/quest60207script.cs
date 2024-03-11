//--- Melia Script -----------------------------------------------------------
// Swift Movement(1)
//--- Description -----------------------------------------------------------
// Quest to Check the Devries Controller Spell Source.
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

[QuestScript(60207)]
public class Quest60207Script : QuestScript
{
	protected override void Load()
	{
		SetId(60207);
		SetName("Swift Movement(1)");
		SetDescription("Check the Devries Controller Spell Source");

		AddPrerequisite(new LevelPrerequisite(308));

		AddObjective("collect0", "Collect 10 Magic Essence(s)", new CollectItemObjective("FIRETOWER691_SQ_1_ITEM", 10));
		AddDrop("FIRETOWER691_SQ_1_ITEM", 7.5f, 58508, 58509, 58510, 58511);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14168));

		AddDialogHook("FIRETOWER691_SQ_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FIRETOWER691_SQ_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER691_SQ_1_1", "FIRETOWER691_SQ_1", "Collect", "It is useless"))
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

		if (character.Inventory.HasItem("FIRETOWER691_SQ_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("FIRETOWER691_SQ_1_ITEM", 10);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Devries Controller Spell Source has been activated");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

