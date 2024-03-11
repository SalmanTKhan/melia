//--- Melia Script -----------------------------------------------------------
// Center of the Formation [Centurion Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Centurion Master.
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

[QuestScript(8727)]
public class Quest8727Script : QuestScript
{
	protected override void Load()
	{
		SetId(8727);
		SetName("Center of the Formation [Centurion Advancement]");
		SetDescription("Meet the Centurion Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia_J1));

		AddDialogHook("JOB_CENT4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CENT4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CENTURION5_1_01", "JOB_CENTURION5_1", "I will prove my abilities", "I'll wait a little bit"))
		{
			case 1:
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

		await dialog.Msg("JOB_CENTURION5_1_03");
		dialog.ShowHelp("TUTO_CLASS_CENTURION");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

