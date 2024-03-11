//--- Melia Script -----------------------------------------------------------
// Followers of Goddess Jurate(1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Revelator Pudhin.
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

[QuestScript(90188)]
public class Quest90188Script : QuestScript
{
	protected override void Load()
	{
		SetId(90188);
		SetName("Followers of Goddess Jurate(1)");
		SetDescription("Speak with Revelator Pudhin");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_9"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_1_MAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_MAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_10_ST", "CORAL_44_1_SQ_10", "I'll help you", "I have other reasons for coming. "))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_10_AG");
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

		if (character.Inventory.HasItem("CORAL_44_1_SQ_10_ITEM", 9))
		{
			character.Inventory.RemoveItem("CORAL_44_1_SQ_10_ITEM", 9);
			await dialog.Msg("CORAL_44_1_SQ_10_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

