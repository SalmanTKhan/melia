//--- Melia Script -----------------------------------------------------------
// Moses' True Feelings (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Cahill.
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

[QuestScript(20241)]
public class Quest20241Script : QuestScript
{
	protected override void Load()
	{
		SetId(20241);
		SetName("Moses' True Feelings (1)");
		SetDescription("Talk to Villager Cahill");

		AddPrerequisite(new LevelPrerequisite(103));

		AddDialogHook("REMAIN39_SQ_MAN", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN39_SQ05_select01", "REMAIN39_SQ05", "Tell Moses about the feelings of the Villager", "About Agailla Flurry", "Better do that yourself"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAINS39_MQ03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAIN39_SQ05_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

