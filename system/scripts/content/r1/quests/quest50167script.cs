//--- Melia Script -----------------------------------------------------------
// Village Curse (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Argis.
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

[QuestScript(50167)]
public class Quest50167Script : QuestScript
{
	protected override void Load()
	{
		SetId(50167);
		SetName("Village Curse (2)");
		SetDescription("Talk to Villager Argis");

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ2"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ3_startnpc1", "TABLELAND_72_SQ3", "No problem", "Please ask someone else."))
		{
			case 1:
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

		await dialog.Msg("TABLELAND_72_SQ3_succ01");
		// Func/TABLE72_SUBQ3_FUNC;
		await dialog.Msg("TABLELAND_72_SQ3_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

