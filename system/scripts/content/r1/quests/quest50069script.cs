//--- Melia Script -----------------------------------------------------------
// The Soldiers' Story
//--- Description -----------------------------------------------------------
// Quest to Look for the hidden book.
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

[QuestScript(50069)]
public class Quest50069Script : QuestScript
{
	protected override void Load()
	{
		SetId(50069);
		SetName("The Soldiers' Story");
		SetDescription("Look for the hidden book");

		AddPrerequisite(new LevelPrerequisite(207));

		AddReward(new ItemReward("UNDER67_SQ1_COPY_BOOK1", 1));
		AddReward(new ItemReward("UNDER67_SQ1_COPY_BOOK2", 1));

		AddDialogHook("UNDER67_BOOK1", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("UNDER_67_SQ010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

