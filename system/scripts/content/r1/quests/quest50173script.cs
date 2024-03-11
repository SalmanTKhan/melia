//--- Melia Script -----------------------------------------------------------
// Village Curse (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50173)]
public class Quest50173Script : QuestScript
{
	protected override void Load()
	{
		SetId(50173);
		SetName("Village Curse (8)");
		SetDescription("Talk to Village Priest Chaleims");

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ8"));

		AddDialogHook("TABLE72_PEAPLE1_2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ9_startnpc1", "TABLELAND_72_SQ9", "Leave it to me", "I need to prepare first."))
		{
			case 1:
				await dialog.Msg("TABLELAND_72_SQ9_startnpc2");
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

		await dialog.Msg("TABLELAND_72_SQ9_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

