//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Spearman
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Spearman.
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

[QuestScript(63016)]
public class Quest63016Script : QuestScript
{
	protected override void Load()
	{
		SetId(63016);
		SetName("Defeat the Orc Spearman");
		SetDescription("Defeat the Orc Spearman");

		AddPrerequisite(new LevelPrerequisite(441));

		AddObjective("kill0", "Kill 55 Orc Spearman(s)", new KillObjective(55, MonsterId.Orc_Double_Axe));

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

