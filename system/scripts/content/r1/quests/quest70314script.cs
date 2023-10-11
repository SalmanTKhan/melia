//--- Melia Script -----------------------------------------------------------
// Digging Herbs [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Submaster.
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

[QuestScript(70314)]
public class Quest70314Script : QuestScript
{
	protected override void Load()
	{
		SetId(70314);
		SetName("Digging Herbs [Priest Advancement]");
		SetDescription("Talk with Priest Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_PRIEST_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PRIEST_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PRIEST3_1_1", "JOB_2_PRIEST3", "Give me any assignment", "I will return next time"))
		{
			case 1:
				await dialog.Msg("JOB_2_PRIEST3_1_2");
				dialog.UnHideNPC("JOB_2_PRIEST3_HERB1");
				dialog.UnHideNPC("JOB_2_PRIEST3_HERB2");
				dialog.UnHideNPC("JOB_2_PRIEST3_HERB3");
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


		return HookResult.Break;
	}
}

