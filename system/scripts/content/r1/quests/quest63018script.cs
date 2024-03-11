//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Peltast
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Peltast.
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

[QuestScript(63018)]
public class Quest63018Script : QuestScript
{
	protected override void Load()
	{
		SetId(63018);
		SetName("Defeat the Orc Peltast");
		SetDescription("Defeat the Orc Peltast");

		AddPrerequisite(new LevelPrerequisite(441));

		AddObjective("kill0", "Kill 65 Orc Peltast(s)", new KillObjective(65, MonsterId.Orc_Shield));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_5", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

