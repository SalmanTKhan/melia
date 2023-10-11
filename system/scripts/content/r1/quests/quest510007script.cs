//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Orsha Purify
//--- Description -----------------------------------------------------------
// Quest to Defeat 8000 monsters in Episode 13-1 area.
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

[QuestScript(510007)]
public class Quest510007Script : QuestScript
{
	protected override void Load()
	{
		SetId(510007);
		SetName("[Weekly] Annihilation - Orsha Purify");
		SetDescription("Defeat 8000 monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 8000 Liepsna Spreader(s) or Liepsna Invader(s) or Liepsna Chaser(s) or Liepsna Destroyer(s) or Darbas Carrier(s) or Darbas Loader(s) or Darbas Miner(s) or Vynmedis(s) or Biblioteca Keeper(s) or Darbas Cleaner(s) or Darbas Leader(s) or Saugumas Sentinel(s) or Saugumas Defender(s) or Saugumas Guardian(s) or Elgesys Malkos(s) or Elgesys Collecter(s) or Darbas Smuggler(s) or Elgesys Guard(s)", new KillObjective(8000, 59576, 59577, 59578, 59579, 59580, 59581, 59582, 59583, 59584, 59585, 59586, 59587, 59588, 59589, 59590, 59591, 59592, 59593));

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

