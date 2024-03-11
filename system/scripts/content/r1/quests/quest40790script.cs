//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Meile.
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

[QuestScript(40790)]
public class Quest40790Script : QuestScript
{
	protected override void Load()
	{
		SetId(40790);
		SetName("Check the Detector's Functionality (1)");
		SetDescription("Talk to Kupole Meile");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_010"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_29_1_SQ_020_ST", "FLASH_29_1_SQ_020", "Ask what happens if we help", "Thanks for saving me, but I will leave now"))
		{
			case 1:
				await dialog.Msg("FLASH_29_1_SQ_020_AC");
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

		await dialog.Msg("FLASH_29_1_SQ_020_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

