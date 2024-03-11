//--- Melia Script -----------------------------------------------------------
// For Those Who Remember Them
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Andrea.
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

[QuestScript(70407)]
public class Quest70407Script : QuestScript
{
	protected override void Load()
	{
		SetId(70407);
		SetName("For Those Who Remember Them");
		SetDescription("Talk to Follower Andrea");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("CASTLE651_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_SQ_02_start", "CASTLE65_1_SQ02", "I'll take a look", "That's unfortunate, but it can't be helped"))
		{
			case 1:
				await dialog.Msg("CASTLE651_SQ_02_agree");
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


		return HookResult.Break;
	}
}

