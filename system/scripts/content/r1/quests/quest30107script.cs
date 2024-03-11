//--- Melia Script -----------------------------------------------------------
// This and That [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Submaster.
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

[QuestScript(30107)]
public class Quest30107Script : QuestScript
{
	protected override void Load()
	{
		SetId(30107);
		SetName("This and That [Hunter Advancement]");
		SetDescription("Talk to the Hunter Submaster");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HUNTER_5_1_select", "JOB_2_HUNTER_5_1", "I'll do it", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_2_HUNTER_5_1_agree");
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

		await dialog.Msg("JOB_2_HUNTER_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

