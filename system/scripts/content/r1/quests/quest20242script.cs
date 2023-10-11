//--- Melia Script -----------------------------------------------------------
// Moses' True Feelings (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Old Man Moses.
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

[QuestScript(20242)]
public class Quest20242Script : QuestScript
{
	protected override void Load()
	{
		SetId(20242);
		SetName("Moses' True Feelings (2)");
		SetDescription("Talk to Old Man Moses");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ05"));

		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN39_SQ06_select01", "REMAIN39_SQ06", "Bring the woods", "Not an appealing attitude so just ignore"))
		{
			case 1:
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

		await dialog.Msg("REMAIN39_SQ06_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

