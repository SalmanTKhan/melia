//--- Melia Script -----------------------------------------------------------
// The Reliable [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Master.
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

[QuestScript(17730)]
public class Quest17730Script : QuestScript
{
	protected override void Load()
	{
		SetId(17730);
		SetName("The Reliable [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia_J1));

		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HOPLITE5_1_select", "JOB_HOPLITE5_1", "I will prove my abilities", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_HOPLITE5_1_prog");
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

		await dialog.Msg("JOB_HOPLITE5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

