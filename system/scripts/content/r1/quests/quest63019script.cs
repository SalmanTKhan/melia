//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Leader
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Leader.
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

[QuestScript(63019)]
public class Quest63019Script : QuestScript
{
	protected override void Load()
	{
		SetId(63019);
		SetName("Defeat the Orc Leader");
		SetDescription("Defeat the Orc Leader");

		AddPrerequisite(new LevelPrerequisite(441));

		AddObjective("kill0", "Kill 10 Orc Leader(s)", new KillObjective(10, MonsterId.Orc_Leader));

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

