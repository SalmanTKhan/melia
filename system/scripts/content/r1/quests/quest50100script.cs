//--- Melia Script -----------------------------------------------------------
// Where Did Everybody Go? (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50100)]
public class Quest50100Script : QuestScript
{
	protected override void Load()
	{
		SetId(50100);
		SetName("Where Did Everybody Go? (2)");
		SetDescription("Talk to Traveling Merchant Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ010"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("BRACKEN632_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_ROZE02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_MQ020_startnpc01", "BRACKEN_63_2_MQ020", "Let's try and find more beads", "I'm sure it'll be nothing"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_2_MQ020_AG");
				// Func/BRACKEN632_ROZE_AI_CREATE;
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

