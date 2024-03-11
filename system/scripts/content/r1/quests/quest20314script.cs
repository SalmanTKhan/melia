//--- Melia Script -----------------------------------------------------------
// Dusty Old Books
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Ruodell.
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

[QuestScript(20314)]
public class Quest20314Script : QuestScript
{
	protected override void Load()
	{
		SetId(20314);
		SetName("Dusty Old Books");
		SetDescription("Talk to Priest Ruodell");

		AddPrerequisite(new LevelPrerequisite(142));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3692));

		AddDialogHook("CHATHEDRAL54_SQ04_PART2", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_SQ04_PART2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_SQ01_PART1", "CHATHEDRAL54_SQ01_PART1", "Leave it to me", "I will help him later"))
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

		await dialog.Msg("CHATHEDRAL54_SQ01_PART1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

