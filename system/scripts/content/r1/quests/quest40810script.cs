//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (3) 
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(40810)]
public class Quest40810Script : QuestScript
{
	protected override void Load()
	{
		SetId(40810);
		SetName("Check the Detector's Functionality (3) ");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_030"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_29_1_SQ_040_ST", "FLASH_29_1_SQ_040", "I'll try to look for them", "I can't help you"))
		{
			case 1:
				await dialog.Msg("FLASH_29_1_SQ_040_AC");
				dialog.UnHideNPC("FLASH_29_1_SOL_SCAR");
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

		await dialog.Msg("FLASH_29_1_SQ_040_COMP");
		dialog.HideNPC("FLASH_29_1_SOL_SCAR");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_29_1_SQ_045");
	}
}

