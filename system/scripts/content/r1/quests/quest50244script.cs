//--- Melia Script -----------------------------------------------------------
// Rebuilding the Study of Magic [Sage Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sage Master.
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

[QuestScript(50244)]
public class Quest50244Script : QuestScript
{
	protected override void Load()
	{
		SetId(50244);
		SetName("Rebuilding the Study of Magic [Sage Advancement]");
		SetDescription("Talk with the Sage Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("SAGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("SAGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SAGE_8_1_START1", "JOB_SAGE_8_1", "I'll try to do it", "This looks like a job for somebody else."))
		{
			case 1:
				await dialog.Msg("JOB_SAGE_8_1_AGREE1");
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

		await dialog.Msg("JOB_SAGE_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

