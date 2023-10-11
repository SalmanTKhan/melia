//--- Melia Script -----------------------------------------------------------
// Activities of a Psychokino [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Submaster.
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

[QuestScript(17630)]
public class Quest17630Script : QuestScript
{
	protected override void Load()
	{
		SetId(17630);
		SetName("Activities of a Psychokino [Psychokino Advancement]");
		SetDescription("Talk to the Psychokino Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PSYCHOKINESIST4_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Red Vubbe Fighter", new KillObjective(1, MonsterId.Boss_Goblin_Warrior_Red_J1));

		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PSYCHOKINESIST4_1_select", "JOB_PSYCHOKINESIST4_1", "I will take the test", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PSYCHOKINESIST4_1_AG");
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

		await dialog.Msg("JOB_PSYCHOKINESIST4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

