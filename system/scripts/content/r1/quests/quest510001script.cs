//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Mutant-type Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 2000 Mutant-type Monsters in Episode 13-1 area.
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

[QuestScript(510001)]
public class Quest510001Script : QuestScript
{
	protected override void Load()
	{
		SetId(510001);
		SetName("[Weekly] Annihilation - Mutant-type Monster");
		SetDescription("Defeat 2000 Mutant-type Monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 2000 Liepsna Spreader(s) or Saugumas Sentinel(s) or Saugumas Guardian(s) or Elgesys Collecter(s) or Elgesys Guard(s)", new KillObjective(2000, 59576, 59587, 59589, 59591, 59593));

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

