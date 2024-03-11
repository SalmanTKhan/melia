//--- Melia Script -----------------------------------------------------------
// Defeat the Viskal
//--- Description -----------------------------------------------------------
// Quest to Defeat the Viskal.
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

[QuestScript(63004)]
public class Quest63004Script : QuestScript
{
	protected override void Load()
	{
		SetId(63004);
		SetName("Defeat the Viskal");
		SetDescription("Defeat the Viskal");

		AddPrerequisite(new LevelPrerequisite(421));

		AddObjective("kill0", "Kill 10 Viskal(s)", new KillObjective(10, MonsterId.Viskal));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

