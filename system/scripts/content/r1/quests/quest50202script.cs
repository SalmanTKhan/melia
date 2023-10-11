//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50202)]
public class Quest50202Script : QuestScript
{
	protected override void Load()
	{
		SetId(50202);
		SetName("Danger the Lurks in the Forest (1)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));

		AddObjective("collect0", "Collect 3 Bunkeybo Skin(s)", new CollectItemObjective("BRACKEN432_SUBQ1_ITEM1", 3));
		AddObjective("collect1", "Collect 3 Bunkeyto Skin(s)", new CollectItemObjective("BRACKEN432_SUBQ1_ITEM2", 3));
		AddDrop("BRACKEN432_SUBQ1_ITEM1", 10f, "darong");
		AddDrop("BRACKEN432_SUBQ1_ITEM2", 10f, "dorong");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14260));

		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ1_START1", "BRACKEN43_2_SQ1", "Don't worry, love, I will help your reseatch.", "I have too much on my hand at the moment."))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ1_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN432_SUBQ1_ITEM1", 3) && character.Inventory.HasItem("BRACKEN432_SUBQ1_ITEM2", 3) && character.Inventory.HasItem("BRACKEN432_SUBQ1_ITEM3", 4) && character.Inventory.HasItem("BRACKEN432_SUBQ1_ITEM4", 4))
		{
			character.Inventory.RemoveItem("BRACKEN432_SUBQ1_ITEM1", 3);
			character.Inventory.RemoveItem("BRACKEN432_SUBQ1_ITEM2", 3);
			character.Inventory.RemoveItem("BRACKEN432_SUBQ1_ITEM3", 4);
			character.Inventory.RemoveItem("BRACKEN432_SUBQ1_ITEM4", 4);
			await dialog.Msg("BRACKEN43_2_SQ1_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

