//--- Melia Script -----------------------------------------------------------
// Alchemist's Story [Chronomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chronomancer Master.
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

[QuestScript(30037)]
public class Quest30037Script : QuestScript
{
	protected override void Load()
	{
		SetId(30037);
		SetName("Alchemist's Story [Chronomancer Advancement]");
		SetDescription("Talk to the Chronomancer Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CHRONO_6_1_select", "JOB_CHRONO_6_1", "I'll help you", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_CHRONO_6_1_agree");
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

		await dialog.Msg("JOB_CHRONO_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

