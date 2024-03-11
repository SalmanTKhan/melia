//--- Melia Script -----------------------------------------------------------
// Great Miko Barrier[Miko Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Miko Master.
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

[QuestScript(30273)]
public class Quest30273Script : QuestScript
{
	protected override void Load()
	{
		SetId(30273);
		SetName("Great Miko Barrier[Miko Advancement]");
		SetDescription("Talk to Miko Master");

		AddPrerequisite(new LevelPrerequisite(185));

		AddDialogHook("MIKO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MIKO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MIKO_6_1_select", "JOB_MIKO_6_1", "I will check up on those barriers.", "The task is too daunting."))
		{
			case 1:
				await dialog.Msg("JOB_MIKO_6_1_agree");
				dialog.UnHideNPC("JOB_MIKO_6_1_CMINE_66_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_UNDER_59_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_CASTLE_67_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_UNDER_68_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_STOWER_60_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_VPRISON_54_1");
				dialog.UnHideNPC("JOB_MIKO_6_1_FTOWER_61_1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_MIKO_6_1_succ");
		dialog.HideNPC("JOB_MIKO_6_1_CMINE_66_1");
		dialog.HideNPC("JOB_MIKO_6_1_UNDER_59_1");
		dialog.HideNPC("JOB_MIKO_6_1_CASTLE_67_1");
		dialog.HideNPC("JOB_MIKO_6_1_UNDER_68_1");
		dialog.HideNPC("JOB_MIKO_6_1_STOWER_60_1");
		dialog.HideNPC("JOB_MIKO_6_1_VPRISON_54_1");
		dialog.HideNPC("JOB_MIKO_6_1_FTOWER_61_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

