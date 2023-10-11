//--- Melia Script -----------------------------------------------------------
// Defeat the Akhlass Petal Warrior
//--- Description -----------------------------------------------------------
// Quest to Defeat the Akhlass Petal Warrior.
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

[QuestScript(63009)]
public class Quest63009Script : QuestScript
{
	protected override void Load()
	{
		SetId(63009);
		SetName("Defeat the Akhlass Petal Warrior");
		SetDescription("Defeat the Akhlass Petal Warrior");

		AddPrerequisite(new LevelPrerequisite(431));

		AddObjective("kill0", "Kill 45 Akhlass Petal Warrior(s)", new KillObjective(45, MonsterId.Aklaspetal_Sword));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

