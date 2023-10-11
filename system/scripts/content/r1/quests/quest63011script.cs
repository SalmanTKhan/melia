//--- Melia Script -----------------------------------------------------------
// Defeat the Ilgaranka
//--- Description -----------------------------------------------------------
// Quest to Defeat the Ilgaranka.
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

[QuestScript(63011)]
public class Quest63011Script : QuestScript
{
	protected override void Load()
	{
		SetId(63011);
		SetName("Defeat the Ilgaranka");
		SetDescription("Defeat the Ilgaranka");

		AddPrerequisite(new LevelPrerequisite(431));

		AddObjective("kill0", "Kill 15 Ilgaranka(s)", new KillObjective(15, MonsterId.Castle_Troll));

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

