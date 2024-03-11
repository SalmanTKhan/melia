//--- Melia Script -----------------------------------------------------------
// Defeat the monsters at Rinksmas Ruins
//--- Description -----------------------------------------------------------
// Quest to Defeat the monsters at Rinksmas Ruins.
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

[QuestScript(63020)]
public class Quest63020Script : QuestScript
{
	protected override void Load()
	{
		SetId(63020);
		SetName("Defeat the monsters at Rinksmas Ruins");
		SetDescription("Defeat the monsters at Rinksmas Ruins");

		AddPrerequisite(new LevelPrerequisite(441));

		AddObjective("kill0", "Kill 130 Orc Spearman(s) or Orc Peltast(s) or Orc Shaman(s) or Orc Leader(s)", new KillObjective(130, 59326, 59327, 59356, 59328));

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

