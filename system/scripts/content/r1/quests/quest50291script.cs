//--- Melia Script -----------------------------------------------------------
// It's Alright
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

[QuestScript(50291)]
public class Quest50291Script : QuestScript
{
	protected override void Load()
	{
		SetId(50291);
		SetName("It's Alright");
		SetDescription("Talk to Kupole Meile");

		AddPrerequisite(new LevelPrerequisite(207));

		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH29_1_HQ1_start1", "FLASH29_1_HQ1", "I'll go and install the sphere.", "I'll do it later"))
		{
			case 1:
				dialog.UnHideNPC("FLASH29_1_HIDDENQ1_OBJ1");
				dialog.UnHideNPC("FLASH29_1_HIDDENQ1_OBJ2");
				dialog.UnHideNPC("FLASH29_1_HIDDENQ1_OBJ3");
				dialog.UnHideNPC("FLASH29_1_HIDDENQ1_OBJ4");
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

		await dialog.Msg("FLASH29_1_HQ1_succ1");
		// Func/FLASH29_1_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

