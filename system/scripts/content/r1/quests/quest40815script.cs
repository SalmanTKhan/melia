//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (4)
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

[QuestScript(40815)]
public class Quest40815Script : QuestScript
{
	protected override void Load()
	{
		SetId(40815);
		SetName("Check the Detector's Functionality (4)");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_040"));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_29_1_SQ_045_ST", "FLASH_29_1_SQ_045", "Send the words of appreciation", "I will stay here for a while"))
		{
			case 1:
				await dialog.Msg("FLASH_29_1_SQ_045_AC");
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

		await dialog.Msg("FLASH_29_1_SQ_045_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_29_1_SQ_050");
	}
}

