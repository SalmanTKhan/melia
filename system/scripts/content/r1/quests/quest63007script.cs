//--- Melia Script -----------------------------------------------------------
// Defeat the Poana
//--- Description -----------------------------------------------------------
// Quest to Defeat the Poana.
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

[QuestScript(63007)]
public class Quest63007Script : QuestScript
{
	protected override void Load()
	{
		SetId(63007);
		SetName("Defeat the Poana");
		SetDescription("Defeat the Poana");

		AddPrerequisite(new LevelPrerequisite(426));

		AddObjective("kill0", "Kill 25 Poana(s)", new KillObjective(25, MonsterId.Poana));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

