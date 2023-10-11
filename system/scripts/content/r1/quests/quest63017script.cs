//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Shaman
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Shaman.
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

[QuestScript(63017)]
public class Quest63017Script : QuestScript
{
	protected override void Load()
	{
		SetId(63017);
		SetName("Defeat the Orc Shaman");
		SetDescription("Defeat the Orc Shaman");

		AddPrerequisite(new LevelPrerequisite(441));

		AddObjective("kill0", "Kill 45 Orc Shaman(s)", new KillObjective(45, MonsterId.Orc_Wand));

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

