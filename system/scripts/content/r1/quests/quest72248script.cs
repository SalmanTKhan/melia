//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72248)]
public class Quest72248Script : QuestScript
{
	protected override void Load()
	{
		SetId(72248);
		SetName("Laima's Spinning Wheel (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(436));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_07"));

		AddObjective("kill0", "Kill 10 Bloguz Goblin Archer(s) or Grey Wolf(s) or Grey Wolf Chief(s) or Necko(s) or Bloguz Goblin Rider(s)", new KillObjective(10, 59354, 59358, 59357, 59360, 59366));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 25288));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("CASTLE102_AUSTEJA_01", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE102_MQ_01_DLG01", "CASTLE102_MQ_01", "Alright", "Sorry, I need more time."))
		{
			case 1:
				dialog.HideNPC("CASTLE102_AUSTEJA_01");
				// Func/SCR_CASTLE102_MQ_01_TRACK_ACTIVE;
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("CASTLE102_MQ_01_DLG09");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

