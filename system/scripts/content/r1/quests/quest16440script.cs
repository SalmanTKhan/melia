//--- Melia Script -----------------------------------------------------------
// Goddess Austeja's Situation
//--- Description -----------------------------------------------------------
// Quest to Listen to Goddess Austeja's story.
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

[QuestScript(16440)]
public class Quest16440Script : QuestScript
{
	protected override void Load()
	{
		SetId(16440);
		SetName("Goddess Austeja's Situation");
		SetDescription("Listen to Goddess Austeja's story");

		AddPrerequisite(new LevelPrerequisite(166));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_MQ_04"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 54780));

		AddDialogHook("SIAULIAI_46_2_AUSTEJA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_AUSTEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_MQ_05_select", "SIAULIAI_46_2_MQ_05", "Listen to the Story", "Let's rest for a while"))
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

		await dialog.Msg("SIAULIAI_46_2_MQ_05_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

