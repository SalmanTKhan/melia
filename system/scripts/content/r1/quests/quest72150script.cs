//--- Melia Script -----------------------------------------------------------
// A Long Tail Gets Caught
//--- Description -----------------------------------------------------------
// Quest to The Call of the Scout Master.
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

[QuestScript(72150)]
public class Quest72150Script : QuestScript
{
	protected override void Load()
	{
		SetId(72150);
		SetName("A Long Tail Gets Caught");
		SetDescription("The Call of the Scout Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SCOUT5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(1, MonsterId.Boss_Deadbone_J1));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_SCOUT1_DLG1", "MASTER_SCOUT1", "I will try", "I'll come back later"))
		{
			case 1:
				await dialog.Msg("JOB_SCOUT5_1_02");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("MASTER_SCOUT1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

