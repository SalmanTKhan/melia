//--- Melia Script -----------------------------------------------------------
// Retreat (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Vilas.
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

[QuestScript(50186)]
public class Quest50186Script : QuestScript
{
	protected override void Load()
	{
		SetId(50186);
		SetName("Retreat (3)");
		SetDescription("Talk to Assistant Commander Vilas");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ2"));

		AddDialogHook("TABLE74_SUBQ_SOLDIER2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER3_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_74_SQ3_startnpc1", "TABLELAND_74_SQ3", "I'll help you get rid of the black wall.", "We should think about this further."))
		{
			case 1:
				await dialog.Msg("TABLELAND_74_SQ3_startnpc2");
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

		await dialog.Msg("TABLELAND_74_SQ3_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

