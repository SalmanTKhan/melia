//--- Melia Script -----------------------------------------------------------
// [Heroic Tale] Stories that didn't Last
//--- Description -----------------------------------------------------------
// Quest to Someone has a story to tell you..
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

[QuestScript(91055)]
public class Quest91055Script : QuestScript
{
	protected override void Load()
	{
		SetId(91055);
		SetName("[Heroic Tale] Stories that didn't Last");
		SetDescription("Someone has a story to tell you.");

		AddPrerequisite(new LevelPrerequisite(450));

		AddDialogHook("TOSHERO_TUTO_NPC_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TOSHERO_TUTO_01_DLG_01", "TOSHERO_TUTO_01", "I'm curious about the story.", "Not interested."))
		{
			case 1:
				await dialog.Msg("TOSHERO_TUTO_01_DLG_02");
				// Func/SCR_MOVE_TO_MISSION_TOSHERO_TUTO;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

