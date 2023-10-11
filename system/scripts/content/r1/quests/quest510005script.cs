//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Medium-sized Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 3000 medium-sized monsters in Episode 13-1 area.
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

[QuestScript(510005)]
public class Quest510005Script : QuestScript
{
	protected override void Load()
	{
		SetId(510005);
		SetName("[Weekly] Annihilation - Medium-sized Monster");
		SetDescription("Defeat 3000 medium-sized monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 3000 Liepsna Chaser(s) or Liepsna Spreader(s) or Darbas Carrier(s) or Darbas Cleaner(s) or Biblioteca Keeper(s) or Saugumas Sentinel(s) or Elgesys Collecter(s) or Elgesys Malkos(s)", new KillObjective(3000, 59578, 59576, 59580, 59585, 59584, 59587, 59591, 59590));

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

