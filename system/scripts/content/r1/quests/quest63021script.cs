//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Cannoneer
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Cannoneer.
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

[QuestScript(63021)]
public class Quest63021Script : QuestScript
{
	protected override void Load()
	{
		SetId(63021);
		SetName("Defeat the Orc Cannoneer");
		SetDescription("Defeat the Orc Cannoneer");

		AddPrerequisite(new LevelPrerequisite(446));

		AddObjective("kill0", "Kill 60 Oak Cannoneer(s)", new KillObjective(60, MonsterId.Orc_Cannon));

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

