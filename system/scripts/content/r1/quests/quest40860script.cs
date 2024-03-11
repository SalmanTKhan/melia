//--- Melia Script -----------------------------------------------------------
// An Unlucky Day
//--- Description -----------------------------------------------------------
// Quest to Look at the suspicious barrier stone.
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

[QuestScript(40860)]
public class Quest40860Script : QuestScript
{
	protected override void Load()
	{
		SetId(40860);
		SetName("An Unlucky Day");
		SetDescription("Look at the suspicious barrier stone");

		AddPrerequisite(new LevelPrerequisite(207));

		AddDialogHook("FLASH_SOUL_COLLECTOR_S1_D", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH_58_SQ_010_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

