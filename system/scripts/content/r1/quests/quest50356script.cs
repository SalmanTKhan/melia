//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50356)]
public class Quest50356Script : QuestScript
{
	protected override void Load()
	{
		SetId(50356);
		SetName("Suspiciously Secretive (1)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ1"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ2_START1", "ABBEY22_5_SQ2", "How shall I conduct the search?", "Do it yourself."))
		{
			case 1:
				await dialog.Msg("ABBEY22_5_SUBQ2_AGR1");
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

		if (character.Inventory.HasItem("ABBEY22_5_SUBQ3_ITEM2", 18))
		{
			character.Inventory.RemoveItem("ABBEY22_5_SUBQ3_ITEM2", 18);
			await dialog.Msg("ABBEY22_5_SUBQ2_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

