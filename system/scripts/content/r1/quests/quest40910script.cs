//--- Melia Script -----------------------------------------------------------
// For Death( 3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Demon Svitrigaila.
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

[QuestScript(40910)]
public class Quest40910Script : QuestScript
{
	protected override void Load()
	{
		SetId(40910);
		SetName("For Death( 3)");
		SetDescription("Talk with Demon Svitrigaila");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_050"));
		AddPrerequisite(new ItemPrerequisite("FLASH_58_SQ_050_ITEM_3", -100));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_060_ST", "FLASH_58_SQ_060", "I'll go there", "I can only help so much"))
		{
			case 1:
				// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD_OFF;
				await dialog.Msg("FLASH_58_SQ_060_AC");
				await Task.Delay(2000);
				dialog.UnHideNPC("FLASH_58_PETRIFICATION_MON");
				// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD;
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

		await dialog.Msg("FLASH_58_SQ_060_COMP");
		dialog.HideNPC("FLASH_58_PETRIFICATION_MON");
		// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD_OFF;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

