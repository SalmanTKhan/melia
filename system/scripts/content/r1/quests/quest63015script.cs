//--- Melia Script -----------------------------------------------------------
// Defeat the Grey Wolf Chief
//--- Description -----------------------------------------------------------
// Quest to Defeat the Grey Wolf Chief.
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

[QuestScript(63015)]
public class Quest63015Script : QuestScript
{
	protected override void Load()
	{
		SetId(63015);
		SetName("Defeat the Grey Wolf Chief");
		SetDescription("Defeat the Grey Wolf Chief");

		AddPrerequisite(new LevelPrerequisite(436));

		AddObjective("kill0", "Kill 10 Grey Wolf Chief(s)", new KillObjective(10, MonsterId.Wolf_Leader));

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

