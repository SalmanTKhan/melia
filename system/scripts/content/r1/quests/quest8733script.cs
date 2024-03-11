//--- Melia Script -----------------------------------------------------------
// Lost Dignity [Quarrel Shooter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Quarrel Shooter Master.
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

[QuestScript(8733)]
public class Quest8733Script : QuestScript
{
	protected override void Load()
	{
		SetId(8733);
		SetName("Lost Dignity [Quarrel Shooter Advancement]");
		SetDescription("Call of the Quarrel Shooter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARREL5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Templeshooter", new KillObjective(1, MonsterId.Boss_Templeshooter_J1));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL5_1_01", "JOB_QUARREL5_1", "I'll go and defeat them", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_QUARREL5_1_02");
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

		await dialog.Msg("JOB_QUARREL5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

