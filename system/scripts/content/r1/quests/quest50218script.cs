//--- Melia Script -----------------------------------------------------------
// Marks of a legend(8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mechen.
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

[QuestScript(50218)]
public class Quest50218Script : QuestScript
{
	protected override void Load()
	{
		SetId(50218);
		SetName("Marks of a legend(8)");
		SetDescription("Talk to Mechen");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ7"));

		AddObjective("collect0", "Collect 13 Romplenuka Magic Essence(s)", new CollectItemObjective("BRACKEN433_SUBQ8_ITEM1", 13));
		AddDrop("BRACKEN433_SUBQ8_ITEM1", 10f, "rompelnuka");

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ8_START1", "BRACKEN43_3_SQ8", "Go to retrieve demon magic", "Tell him to make his apprentices get it"))
		{
			case 1:
				// Func/BRACKEN433_SUBQ8_AGREE_FUNC;
				dialog.HideNPC("BRACKEN433_SUBQ1_NPC2");
				dialog.HideNPC("BRACKEN433_SUBQ3_NPC2");
				dialog.HideNPC("BRACKEN433_SUBQ5_NPC2");
				await dialog.Msg("FadeOutIN/1000");
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

		if (character.Inventory.HasItem("BRACKEN433_SUBQ8_ITEM1", 13))
		{
			character.Inventory.RemoveItem("BRACKEN433_SUBQ8_ITEM1", 13);
			await dialog.Msg("BRACKEN43_3_SQ8_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

