//--- Melia Script -----------------------------------------------------------
// Rose's Friends (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50091)]
public class Quest50091Script : QuestScript
{
	protected override void Load()
	{
		SetId(50091);
		SetName("Rose's Friends (1)");
		SetDescription("Talk to Traveling Merchant Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ010"));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_ROZE", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_ROZE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_MQ020_startnpc01", "BRACKEN_63_1_MQ020", "I'll help you find your colleagues", "About the merchants and the letter", "I think it's best to get away from here"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_1_MQ020_startnpc02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("BRACKEN_63_1_MQ020_ADD");
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

