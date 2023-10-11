//--- Melia Script -----------------------------------------------------------
// Demons here too..?
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Narius.
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

[QuestScript(90199)]
public class Quest90199Script : QuestScript
{
	protected override void Load()
	{
		SetId(90199);
		SetName("Demons here too..?");
		SetDescription("Speak with Loremaster Narius");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_100"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_1_MAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_MAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_110_ST", "CORAL_44_1_SQ_110", "I can handle it", "I'll do it later."))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_110_AG");
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

		if (character.Inventory.HasItem("CORAL_44_1_SQ_110_ITEM", 12))
		{
			character.Inventory.RemoveItem("CORAL_44_1_SQ_110_ITEM", 12);
			await dialog.Msg("CORAL_44_1_SQ_110_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

