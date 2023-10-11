//--- Melia Script -----------------------------------------------------------
// Real Experiences of Elementalist [Elementalist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elementalist Master.
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

[QuestScript(30105)]
public class Quest30105Script : QuestScript
{
	protected override void Load()
	{
		SetId(30105);
		SetName("Real Experiences of Elementalist [Elementalist Advancement]");
		SetDescription("Talk to the Elementalist Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_WARLOCK4_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(1, MonsterId.Boss_Reaverpede_J1));

		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_ELEMENTALIST_5_1_select", "JOB_2_ELEMENTALIST_5_1", "What should I do?", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_2_ELEMENTALIST_5_1_agree");
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

		await dialog.Msg("JOB_2_ELEMENTALIST_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

