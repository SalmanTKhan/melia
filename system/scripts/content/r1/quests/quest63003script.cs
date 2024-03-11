//--- Melia Script -----------------------------------------------------------
// Defeat the Sodinincuz
//--- Description -----------------------------------------------------------
// Quest to Defeat the Sodinincuz.
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

[QuestScript(63003)]
public class Quest63003Script : QuestScript
{
	protected override void Load()
	{
		SetId(63003);
		SetName("Defeat the Sodinincuz");
		SetDescription("Defeat the Sodinincuz");

		AddPrerequisite(new LevelPrerequisite(421));

		AddObjective("kill0", "Kill 25 Sodinincuz(s)", new KillObjective(25, MonsterId.Sodininkas));

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

