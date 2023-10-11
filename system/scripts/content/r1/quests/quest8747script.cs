//--- Melia Script -----------------------------------------------------------
// The Task of Gaining the Mind [Sadhu]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sadhu Master.
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

[QuestScript(8747)]
public class Quest8747Script : QuestScript
{
	protected override void Load()
	{
		SetId(8747);
		SetName("The Task of Gaining the Mind [Sadhu]");
		SetDescription("Talk to the Sadhu Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia_J1));

		AddDialogHook("JOB_SADU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SADU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SADU5_1_01", "JOB_SADU5_1", "Ask what to do", "Tell him it won't be helpful"))
		{
			case 1:
				await dialog.Msg("JOB_SADU5_1_02");
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

		await dialog.Msg("JOB_SADU5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

