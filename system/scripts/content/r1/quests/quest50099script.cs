//--- Melia Script -----------------------------------------------------------
// Where Did Everybody Go? (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Traveling Merchant Rose to Knidos Jungle.
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

[QuestScript(50099)]
public class Quest50099Script : QuestScript
{
	protected override void Load()
	{
		SetId(50099);
		SetName("Where Did Everybody Go? (1)");
		SetDescription("Follow Traveling Merchant Rose to Knidos Jungle");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ040"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 448));
		AddReward(new ItemReward("Drug_SP1_Q", 30));

		AddDialogHook("BRACKEN632_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_MQ010_startnpc01", "BRACKEN_63_2_MQ010", "I'm worried about the demons; I'll check in on your people", "First, let's go to Orsha and ask around"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_2_MQ010_AG");
				dialog.HideNPC("BRACKEN632_ROZE01");
				await dialog.Msg("FadeOutIN/1000");
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

