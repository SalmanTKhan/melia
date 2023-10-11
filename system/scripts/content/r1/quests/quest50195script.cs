//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
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

[QuestScript(50195)]
public class Quest50195Script : QuestScript
{
	protected override void Load()
	{
		SetId(50195);
		SetName("The Goddess' Flower (3)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new LevelPrerequisite(307));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ2"));

		AddObjective("collect0", "Collect 14 Lyecorn Essence(s)", new CollectItemObjective("BRACKEN431_SUBQ3_ITEM1", 14));
		AddDrop("BRACKEN431_SUBQ3_ITEM1", 10f, "Rakon");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ3_START1", "BRACKEN43_1_SQ3", "How do I do that?", "You've got hands, right? Do it yourself."))
		{
			case 1:
				await dialog.Msg("BRACKEN43_1_SQ3_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN431_SUBQ3_ITEM1", 14))
		{
			character.Inventory.RemoveItem("BRACKEN431_SUBQ3_ITEM1", 14);
			await dialog.Msg("BRACKEN43_1_SQ3_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

