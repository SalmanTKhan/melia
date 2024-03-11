//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Large-sized Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 3000 large-sized monsters in Episode 13-1 area.
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

[QuestScript(510004)]
public class Quest510004Script : QuestScript
{
	protected override void Load()
	{
		SetId(510004);
		SetName("[Weekly] Annihilation - Large-sized Monster");
		SetDescription("Defeat 3000 large-sized monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 3000 Liepsna Destroyer(s) or Darbas Miner(s) or Darbas Leader(s) or Saugumas Guardian(s) or Elgesys Guard(s)", new KillObjective(3000, 59579, 59582, 59586, 59589, 59593));

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

