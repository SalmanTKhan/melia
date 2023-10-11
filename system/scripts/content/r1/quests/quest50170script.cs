//--- Melia Script -----------------------------------------------------------
// Village Curse (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50170)]
public class Quest50170Script : QuestScript
{
	protected override void Load()
	{
		SetId(50170);
		SetName("Village Curse (5)");
		SetDescription("Talk to Village Priest Chaleims");

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ5"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ6_startnpc1", "TABLELAND_72_SQ6", "I'll help you gather the divine energy.", "I'm still a little unprepared."))
		{
			case 1:
				await dialog.Msg("TABLELAND_72_SQ6_startnpc2");
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

		await dialog.Msg("TABLELAND_72_SQ6_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

