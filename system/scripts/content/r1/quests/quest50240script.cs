//--- Melia Script -----------------------------------------------------------
// Corrupted Plant [Druid Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Druid Master.
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

[QuestScript(50240)]
public class Quest50240Script : QuestScript
{
	protected override void Load()
	{
		SetId(50240);
		SetName("Corrupted Plant [Druid Advancement]");
		SetDescription("Talk to the Druid Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DRUID_7_1_START1", "JOB_DRUID_7_1", "I will purify the plants.", "That task doesn't suit me at all."))
		{
			case 1:
				dialog.UnHideNPC("JOB_3_DRUID_OBJ");
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

		await dialog.Msg("JOB_DRUID_7_1_SUCC1");
		dialog.HideNPC("JOB_3_DRUID_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

