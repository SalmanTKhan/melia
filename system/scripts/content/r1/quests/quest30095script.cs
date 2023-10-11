//--- Melia Script -----------------------------------------------------------
// Elementary Understanding of Elements [Elementalist Advancement]
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

[QuestScript(30095)]
public class Quest30095Script : QuestScript
{
	protected override void Load()
	{
		SetId(30095);
		SetName("Elementary Understanding of Elements [Elementalist Advancement]");
		SetDescription("Talk to the Elementalist Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_ELEMENTALIST_4_1_select", "JOB_2_ELEMENTALIST_4_1", "I will take them all out.", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_2_ELEMENTALIST_4_1_agree");
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

		await dialog.Msg("JOB_2_ELEMENTALIST_4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

