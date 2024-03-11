//--- Melia Script -----------------------------------------------------------
// Better Offerings
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90075)]
public class Quest90075Script : QuestScript
{
	protected override void Load()
	{
		SetId(90075);
		SetName("Better Offerings");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_6"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 1));

		AddDialogHook("CORAL_32_2_DARUL2", "BeforeStart", BeforeStart);
		AddDialogHook("FED_ACCESSORY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_7_ST", "CORAL_32_2_SQ_7", "How can I help you?", "I'm sorry, I don't think I can help you any longer."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_7_AG");
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

		if (character.Inventory.HasItem("CORAL_32_2_SQ_3_ITEM", 5))
		{
			character.Inventory.RemoveItem("CORAL_32_2_SQ_3_ITEM", 5);
			await dialog.Msg("CORAL_32_2_SQ_7_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CORAL_32_2_SQ_8");
	}
}

