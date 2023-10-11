//--- Melia Script -----------------------------------------------------------
// Attitude Towards the Dark Property [Elementalist Advancement]
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

[QuestScript(30111)]
public class Quest30111Script : QuestScript
{
	protected override void Load()
	{
		SetId(30111);
		SetName("Attitude Towards the Dark Property [Elementalist Advancement]");
		SetDescription("Talk to the Elementalist Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUELE5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Netherbovine", new KillObjective(1, MonsterId.Boss_NetherBovine_J1));

		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_ELEMENTALIST_6_1_select", "JOB_2_ELEMENTALIST_6_1", "There can be no weaknesses", "I'll come back after I train a bit more"))
		{
			case 1:
				await dialog.Msg("JOB_2_ELEMENTALIST_6_1_agree");
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

		await dialog.Msg("JOB_2_ELEMENTALIST_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

