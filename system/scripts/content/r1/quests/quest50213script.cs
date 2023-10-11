//--- Melia Script -----------------------------------------------------------
// Marks of a legend(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Woognis.
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

[QuestScript(50213)]
public class Quest50213Script : QuestScript
{
	protected override void Load()
	{
		SetId(50213);
		SetName("Marks of a legend(3)");
		SetDescription("Talk to Woognis");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ2"));

		AddObjective("collect0", "Collect 9 Vilkas Fur(s)", new CollectItemObjective("BRACKEN433_SUBQ3_ITEM1", 9));
		AddDrop("BRACKEN433_SUBQ3_ITEM1", 10f, 58453, 58457);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ3_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ3_START1", "BRACKEN43_3_SQ3", "Agree to find Vilkas fur", "Say that you wish him the best of luck"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_3_SQ3_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN433_SUBQ3_ITEM1", 9))
		{
			character.Inventory.RemoveItem("BRACKEN433_SUBQ3_ITEM1", 9);
			await dialog.Msg("BRACKEN43_3_SQ3_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

