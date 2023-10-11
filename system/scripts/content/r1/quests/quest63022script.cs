//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Flagbearer
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Flagbearer.
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

[QuestScript(63022)]
public class Quest63022Script : QuestScript
{
	protected override void Load()
	{
		SetId(63022);
		SetName("Defeat the Orc Flagbearer");
		SetDescription("Defeat the Orc Flagbearer");

		AddPrerequisite(new LevelPrerequisite(446));

		AddObjective("kill0", "Kill 70 Orc Flagbearer(s)", new KillObjective(70, MonsterId.Orc_Flag));

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

