//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Thaumaturge [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Thaumaturge Master.
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

[QuestScript(19180)]
public class Quest19180Script : QuestScript
{
	protected override void Load()
	{
		SetId(19180);
		SetName("Complete the Mission of a Thaumaturge [Thaumaturge Advancement]");
		SetDescription("Meet the Thaumaturge Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUELE5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Netherbovine", new KillObjective(1, MonsterId.Boss_NetherBovine_J1));

		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_THAUMATURGE5_1_ST", "JOB_THAUMATURGE5_1", "Yes", "No"))
		{
			case 1:
				await dialog.Msg("JOB_THAUMATURGE5_1_AC");
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

		await dialog.Msg("JOB_THAUMATURGE5_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

