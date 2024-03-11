//--- Melia Script -----------------------------------------------------------
// One Will Get Caught If One's Tail Is Too Long [Scout Advancement]
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

[QuestScript(8737)]
public class Quest8737Script : QuestScript
{
	protected override void Load()
	{
		SetId(8737);
		SetName("One Will Get Caught If One's Tail Is Too Long [Scout Advancement]");
		SetDescription("The Call of the Scout Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SCOUT5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(1, MonsterId.Boss_Deadbone_J1));

		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SCOUT5_1_01", "JOB_SCOUT5_1", "Give me a mission to prove my abilities", "I'll come back later"))
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

		await dialog.Msg("JOB_SCOUT5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

