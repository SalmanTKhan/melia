//--- Melia Script -----------------------------------------------------------
// Refugees of Mishekan Forest(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Curtis.
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

[QuestScript(50253)]
public class Quest50253Script : QuestScript
{
	protected override void Load()
	{
		SetId(50253);
		SetName("Refugees of Mishekan Forest(4)");
		SetDescription("Talk to Curtis");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES56_1_SQ5"));

		AddObjective("collect0", "Collect 15 Flowlon Leather(s)", new CollectItemObjective("WHITETREES561_SUBQ6_ITEM", 15));
		AddDrop("WHITETREES561_SUBQ6_ITEM", 10f, "floron");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15369));

		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ6_START1", "WHITETREES56_1_SQ6", "I will get the leather", "I have some urgent thing to do"))
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

		if (character.Inventory.HasItem("WHITETREES561_SUBQ6_ITEM", 15))
		{
			character.Inventory.RemoveItem("WHITETREES561_SUBQ6_ITEM", 15);
			await dialog.Msg("WHITETREES561_SUBQ6_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

