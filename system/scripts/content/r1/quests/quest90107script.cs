//--- Melia Script -----------------------------------------------------------
// Making the Magic Sphere (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90107)]
public class Quest90107Script : QuestScript
{
	protected override void Load()
	{
		SetId(90107);
		SetName("Making the Magic Sphere (2)");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_120"));

		AddObjective("collect0", "Collect 8 Glimmering Powder(s)", new CollectItemObjective("MAPLE_25_3_SQ_120_ITEM", 8));
		AddDrop("MAPLE_25_3_SQ_120_ITEM", 9f, "nacorngfly");

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_130_ST", "MAPLE_25_3_SQ_130", "What's the glimmering powder?", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_130_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_3_SQ_120_ITEM", 8))
		{
			character.Inventory.RemoveItem("MAPLE_25_3_SQ_120_ITEM", 8);
			await dialog.Msg("MAPLE_25_3_SQ_130_SU");
			// Func/MAPLE_25_3_SQ_130_RUN;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

