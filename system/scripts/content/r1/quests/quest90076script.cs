//--- Melia Script -----------------------------------------------------------
// What Interests You These Days
//--- Description -----------------------------------------------------------
// Quest to Talk to Accessory Merchant Joana.
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

[QuestScript(90076)]
public class Quest90076Script : QuestScript
{
	protected override void Load()
	{
		SetId(90076);
		SetName("What Interests You These Days");
		SetDescription("Talk to Accessory Merchant Joana");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_7"));
		AddPrerequisite(new ItemPrerequisite("CORAL_32_2_SQ_3_ITEM", -100));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("CORAL_32_2_SQ_8_ITEM2", 4));
		AddReward(new ItemReward("Vis", 93060));
		AddReward(new ItemReward("expCard12", 2));

		AddDialogHook("FED_ACCESSORY", "BeforeStart", BeforeStart);
		AddDialogHook("FED_ACCESSORY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_8_ST", "CORAL_32_2_SQ_8", "Okay, let's do that.", "That's too difficult for me."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_8_AG");
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

		if (character.Inventory.HasItem("CORAL_32_2_SQ_8_ITEM", 8))
		{
			character.Inventory.RemoveItem("CORAL_32_2_SQ_8_ITEM", 8);
			await dialog.Msg("CORAL_32_2_SQ_8_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CORAL_32_2_SQ_9");
	}
}

