//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Fletcher Master.
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

[QuestScript(72146)]
public class Quest72146Script : QuestScript
{
	protected override void Load()
	{
		SetId(72146);
		SetName("Disturbance of the Winged Beast (3)");
		SetDescription("Talk to the Fletcher Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MASTER_PELTASTA2_3_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("MASTER_PELTASTA2_2"));

		AddObjective("kill0", "Kill 1 Moa", new KillObjective(1, MonsterId.Boss_Moa_J1));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_PELTASTA2_3_DLG1", "MASTER_PELTASTA2_3", "Is there any other way?", "Give up"))
		{
			case 1:
				await dialog.Msg("JOB_PELTASTA4_3_AG");
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

		await dialog.Msg("JOB_PELTASTA4_3_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_PELTASTA2_4");
	}
}

