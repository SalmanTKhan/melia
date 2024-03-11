//--- Melia Script -----------------------------------------------------------
// Purification of the Stream, Recovery of the Tree (1)
//--- Description -----------------------------------------------------------
// Quest to Purify the Pond of Silence.
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

[QuestScript(19940)]
public class Quest19940Script : QuestScript
{
	protected override void Load()
	{
		SetId(19940);
		SetName("Purification of the Stream, Recovery of the Tree (1)");
		SetDescription("Purify the Pond of Silence");

		AddPrerequisite(new LevelPrerequisite(133));

		AddDialogHook("PILGRIM52_SPRING", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_POT_GET", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_080_ST", "PILGRIM52_SQ_080", "Read the notice on how to purify the stream.", "Cancel"))
		{
			case 1:
				dialog.UnHideNPC("PILGRIM52_PLACE01");
				dialog.UnHideNPC("PILGRIM52_PLACE02");
				dialog.UnHideNPC("PILGRIM52_PLACE03");
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

		dialog.HideNPC("PILGRIM52_PLACE03");
		dialog.HideNPC("PILGRIM52_PLACE02");
		dialog.HideNPC("PILGRIM52_PLACE01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

