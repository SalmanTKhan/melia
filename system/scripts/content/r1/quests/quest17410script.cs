//--- Melia Script -----------------------------------------------------------
// Still Needs Memory [Bokor Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Meet the Krivis Master.
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

[QuestScript(17410)]
public class Quest17410Script : QuestScript
{
	protected override void Load()
	{
		SetId(17410);
		SetName("Still Needs Memory [Bokor Advancement] (4)");
		SetDescription("Meet the Krivis Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BOCOR4_4_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));
		AddPrerequisite(new CompletedPrerequisite("JOB_BOCOR4_3"));

		AddObjective("kill0", "Kill 1 Tutu", new KillObjective(1, MonsterId.Boss_Tutu_J1));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BOCOR4_4_ST", "JOB_BOCOR4_4", "I will defeat Tutu", "Give me some time to prepare"))
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

		await dialog.Msg("JOB_BOCOR4_4_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

