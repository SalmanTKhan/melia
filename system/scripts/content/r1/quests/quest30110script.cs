//--- Melia Script -----------------------------------------------------------
// Controlling Magic Test [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Thaumaturge Submaster.
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

[QuestScript(30110)]
public class Quest30110Script : QuestScript
{
	protected override void Load()
	{
		SetId(30110);
		SetName("Controlling Magic Test [Thaumaturge Advancement]");
		SetDescription("Talk to the Thaumaturge Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_THAUMATURGE_6_1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(185));

		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_THAUMATURGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_THAUMATURGE_6_1_select", "JOB_2_THAUMATURGE_6_1", "I'll show you", "I'm not powerful enough for that yet"))
		{
			case 1:
				await dialog.Msg("JOB_2_THAUMATURGE_6_1_agree");
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

		await dialog.Msg("JOB_2_THAUMATURGE_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

