//--- Melia Script -----------------------------------------------------------
// Smelly Pursuit
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Simonas.
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

[QuestScript(90023)]
public class Quest90023Script : QuestScript
{
	protected override void Load()
	{
		SetId(90023);
		SetName("Smelly Pursuit");
		SetDescription("Talk to Merchant Simonas");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_3"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_4_ST", "CORAL_32_1_SQ_4", "I will investigate it.", "I'm busy"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_4_AG");
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

		if (character.Inventory.HasItem("CORAL_32_1_SQ_4_ITEM", 1))
		{
			character.Inventory.RemoveItem("CORAL_32_1_SQ_4_ITEM", 1);
			await dialog.Msg("CORAL_32_1_SQ_4_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

