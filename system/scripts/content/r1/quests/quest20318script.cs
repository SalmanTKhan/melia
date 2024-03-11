//--- Melia Script -----------------------------------------------------------
// Surprise Attack
//--- Description -----------------------------------------------------------
// Quest to Check the Karuna Altar.
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

[QuestScript(20318)]
public class Quest20318Script : QuestScript
{
	protected override void Load()
	{
		SetId(20318);
		SetName("Surprise Attack");
		SetDescription("Check the Karuna Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL54_SQ05_PART2_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(142));

		AddObjective("kill0", "Kill 1 Riteris", new KillObjective(1, MonsterId.Boss_Riteris));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3692));

		AddDialogHook("CHATHEDRAL54_MQ04_PART2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

