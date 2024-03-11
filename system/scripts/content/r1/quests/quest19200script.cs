//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Sorcerer [Sorcerer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Sorcerer Master.
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

[QuestScript(19200)]
public class Quest19200Script : QuestScript
{
	protected override void Load()
	{
		SetId(19200);
		SetName("Complete the Mission of a Sorcerer [Sorcerer Advancement]");
		SetDescription("Meet the Sorcerer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CHROSOC5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter_J1));

		AddDialogHook("JOB_SORCERER4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SORCERER4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SORCERER5_1_ST", "JOB_SORCERER5_1", "I will defeat the Necroventor", "Decline"))
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

		await dialog.Msg("JOB_SORCERER5_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

