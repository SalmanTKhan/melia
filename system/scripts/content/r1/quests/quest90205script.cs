//--- Melia Script -----------------------------------------------------------
// Purification Ritual 
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90205)]
public class Quest90205Script : QuestScript
{
	protected override void Load()
	{
		SetId(90205);
		SetName("Purification Ritual ");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(331));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_50"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_2_SQ_60_ST", "CORAL_44_2_SQ_60", "I'll help with the purification", "Tell me when you are finished"))
		{
			case 1:
				await dialog.Msg("CORAL_44_2_SQ_60_AG");
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

		if (character.Inventory.HasItem("CORAL_44_2_SQ_60_ITEM2", 10))
		{
			character.Inventory.RemoveItem("CORAL_44_2_SQ_60_ITEM2", 10);
			await dialog.Msg("CORAL_44_2_SQ_60_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

