//--- Melia Script -----------------------------------------------------------
// Making Do With What You Have
//--- Description -----------------------------------------------------------
// Quest to Talk with Mesafasla Assistant Commander Gorman.
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

[QuestScript(70204)]
public class Quest70204Script : QuestScript
{
	protected override void Load()
	{
		SetId(70204);
		SetName("Making Do With What You Have");
		SetDescription("Talk with Mesafasla Assistant Commander Gorman");

		AddPrerequisite(new LevelPrerequisite(212));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_1_SQ04"));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_05_1", "TABLELAND28_1_SQ05", "How can I help you?", "I can't help you with that"))
		{
			case 1:
				await dialog.Msg("TABLELAND28_1_SQ_05_2");
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

		await dialog.Msg("TABLELAND28_1_SQ_05_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

