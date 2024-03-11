//--- Melia Script -----------------------------------------------------------
// Retreat (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Scout Boas.
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

[QuestScript(50187)]
public class Quest50187Script : QuestScript
{
	protected override void Load()
	{
		SetId(50187);
		SetName("Retreat (4)");
		SetDescription("Talk to Scout Boas");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ3"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("TABLE74_SUBQ_SOLDIER3_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER3_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_74_SQ4_startnpc1", "TABLELAND_74_SQ4", "I'll help you get ready.", "We need to find another way"))
		{
			case 1:
				await dialog.Msg("TABLELAND_74_SQ4_startnpc2");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("TABLE74_SUBQ_SOLDIER3_1");
				// Func/TABLE74_SUBQ4_AGREE_FUNC;
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

		await dialog.Msg("TABLELAND_74_SQ4_succ1");
		// Func/TABLELAND74_SUBQ4_COMPLETE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

