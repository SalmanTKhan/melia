//--- Melia Script -----------------------------------------------------------
// Defeat the Orc Captain
//--- Description -----------------------------------------------------------
// Quest to Defeat the Orc Captain.
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

[QuestScript(63023)]
public class Quest63023Script : QuestScript
{
	protected override void Load()
	{
		SetId(63023);
		SetName("Defeat the Orc Captain");
		SetDescription("Defeat the Orc Captain");

		AddPrerequisite(new LevelPrerequisite(446));

		AddObjective("kill0", "Kill 10 Orc Captain(s)", new KillObjective(10, MonsterId.Orc_Glaive));

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

