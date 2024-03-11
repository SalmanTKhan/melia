//--- Melia Script -----------------------------------------------------------
// Convincing Lord Joquvas(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Roberta.
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

[QuestScript(70829)]
public class Quest70829Script : QuestScript
{
	protected override void Load()
	{
		SetId(70829);
		SetName("Convincing Lord Joquvas(4)");
		SetDescription("Talk to Roberta");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ09"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_07_2", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_07_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_10_start", "MAPLE23_2_SQ10", "Agree to the terms", "Say that he should keep his end of the promise"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_10_agree");
				// Func/SCR_MAPLE232_SQ_10_F;
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

		await dialog.Msg("MAPLE232_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

