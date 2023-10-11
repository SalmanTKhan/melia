//--- Melia Script -----------------------------------------------------------
// Defeat the Nuka Warrior, Nuo Assassin
//--- Description -----------------------------------------------------------
// Quest to Defeat the Nuka Warrior, Nuo Assassin.
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

[QuestScript(63008)]
public class Quest63008Script : QuestScript
{
	protected override void Load()
	{
		SetId(63008);
		SetName("Defeat the Nuka Warrior, Nuo Assassin");
		SetDescription("Defeat the Nuka Warrior, Nuo Assassin");

		AddPrerequisite(new LevelPrerequisite(431));

		AddObjective("kill0", "Kill 60 Nuka Warrior(s) or Nuo Assassin(s)", new KillObjective(60, 59332, 59333));

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

