//--- Melia Script -----------------------------------------------------------
// Defeat Monsters at the Road of Demise
//--- Description -----------------------------------------------------------
// Quest to Defeat Monsters at the Road of Demise.
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

[QuestScript(63024)]
public class Quest63024Script : QuestScript
{
	protected override void Load()
	{
		SetId(63024);
		SetName("Defeat Monsters at the Road of Demise");
		SetDescription("Defeat Monsters at the Road of Demise");

		AddPrerequisite(new LevelPrerequisite(446));

		AddObjective("kill0", "Kill 140 Oak Cannoneer(s) or Orc Flagbearer(s) or Orc Captain(s)", new KillObjective(140, 59329, 59331, 59355));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_6", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

