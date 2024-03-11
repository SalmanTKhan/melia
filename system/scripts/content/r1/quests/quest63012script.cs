//--- Melia Script -----------------------------------------------------------
// Defeat the Bloguz Goblin Rider, Necko
//--- Description -----------------------------------------------------------
// Quest to Defeat the Bloguz Goblin Rider, Necko.
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

[QuestScript(63012)]
public class Quest63012Script : QuestScript
{
	protected override void Load()
	{
		SetId(63012);
		SetName("Defeat the Bloguz Goblin Rider, Necko");
		SetDescription("Defeat the Bloguz Goblin Rider, Necko");

		AddPrerequisite(new LevelPrerequisite(436));

		AddObjective("kill0", "Kill 65 Bloguz Goblin Rider(s) or Necko(s)", new KillObjective(65, 59366, 59360));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_4", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

