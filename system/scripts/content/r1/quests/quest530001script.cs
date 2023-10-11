//--- Melia Script -----------------------------------------------------------
// [Repetition] Salvation - World Purify
//--- Description -----------------------------------------------------------
// Quest to Defeat 60000 of monsters in Episode 13-1 area.
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

[QuestScript(530001)]
public class Quest530001Script : QuestScript
{
	protected override void Load()
	{
		SetId(530001);
		SetName("[Repetition] Salvation - World Purify");
		SetDescription("Defeat 60000 of monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("REPUTATION_OPEN_QUEST"), new CompletedPrerequisite("P_R_EP13_2"), new CompletedPrerequisite("P_R_EP13_3"));

		AddObjective("kill0", "Kill 60000 Liepsna Spreader(s) or Liepsna Invader(s) or Liepsna Chaser(s) or Liepsna Destroyer(s) or Darbas Carrier(s) or Darbas Loader(s) or Darbas Miner(s) or Vynmedis(s) or Biblioteca Keeper(s) or Darbas Cleaner(s) or Darbas Leader(s) or Saugumas Sentinel(s) or Saugumas Defender(s) or Saugumas Guardian(s) or Elgesys Malkos(s) or Elgesys Collecter(s) or Darbas Smuggler(s) or Elgesys Guard(s)", new KillObjective(60000, 59576, 59577, 59578, 59579, 59580, 59581, 59582, 59583, 59584, 59585, 59586, 59587, 59588, 59589, 59590, 59591, 59592, 59593));

		AddReward(new ItemReward("reputation_Coin", 20000));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

