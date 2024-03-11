//--- Melia Script -----------------------------------------------------------
// Defeat the Bloguz Goblin Archer
//--- Description -----------------------------------------------------------
// Quest to Defeat the Bloguz Goblin Archer.
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

[QuestScript(63014)]
public class Quest63014Script : QuestScript
{
	protected override void Load()
	{
		SetId(63014);
		SetName("Defeat the Bloguz Goblin Archer");
		SetDescription("Defeat the Bloguz Goblin Archer");

		AddPrerequisite(new LevelPrerequisite(436));

		AddObjective("kill0", "Kill 45 Bloguz Goblin Archer(s)", new KillObjective(45, MonsterId.Castle_Goblin_Archer));

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

