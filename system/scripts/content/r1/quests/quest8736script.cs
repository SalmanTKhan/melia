//--- Melia Script -----------------------------------------------------------
// Swiftness [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call for the Wugushi Submaster .
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

[QuestScript(8736)]
public class Quest8736Script : QuestScript
{
	protected override void Load()
	{
		SetId(8736);
		SetName("Swiftness [Wugushi Advancement]");
		SetDescription("Call for the Wugushi Submaster ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_WUGU5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Rajatoad", new KillObjective(1, MonsterId.Boss_Rajatoad_J1));

		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WUGU5_1_01", "JOB_WUGU5_1", "I'll go there", "Tell him its too dangerous"))
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

		await dialog.Msg("JOB_WUGU5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

