//--- Melia Script -----------------------------------------------------------
// Making Arrowheads
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Reina.
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

[QuestScript(70109)]
public class Quest70109Script : QuestScript
{
	protected override void Load()
	{
		SetId(70109);
		SetName("Making Arrowheads");
		SetDescription("Talk to Hunter Reina");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ05"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_SQ_04_1", "THORN39_2_SQ04", "Listen what happened", "Reject since there isn't anything to do"))
		{
			case 1:
				await dialog.Msg("THORN39_2_SQ_04_2");
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

		if (character.Inventory.HasItem("THORN39_2_SQ04_ITEM", 18))
		{
			character.Inventory.RemoveItem("THORN39_2_SQ04_ITEM", 18);
			await dialog.Msg("THORN39_2_SQ_04_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

