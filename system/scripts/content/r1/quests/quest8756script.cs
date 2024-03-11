//--- Melia Script -----------------------------------------------------------
// The Final Mission (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wandering Spirit.
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

[QuestScript(8756)]
public class Quest8756Script : QuestScript
{
	protected override void Load()
	{
		SetId(8756);
		SetName("The Final Mission (4)");
		SetDescription("Talk to the Wandering Spirit");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ03"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_GHOST", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN39_SQ03_GIRL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("Func/REMAIN39_SQ03_BAL", "REMAIN39_SQ04", "Why are you roaming around?", "Ignore"))
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

		await dialog.Msg("REMAIN39_SQ04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

