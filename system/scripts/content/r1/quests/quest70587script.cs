//--- Melia Script -----------------------------------------------------------
// Escorting a high officer of the Order
//--- Description -----------------------------------------------------------
// Quest to Talk to High Officer Medea.
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

[QuestScript(70587)]
public class Quest70587Script : QuestScript
{
	protected override void Load()
	{
		SetId(70587);
		SetName("Escorting a high officer of the Order");
		SetDescription("Talk to High Officer Medea");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ07"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_08_start", "PILGRIM41_5_SQ08", "Say that you will go to a person that can watch over the high officer", "Say that you cannot beleive what they are saying"))
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

		await dialog.Msg("PILGRIM415_SQ_08_succ1");
		await dialog.Msg("FadeOutIN/1000");
		await Task.Delay(500);
		await dialog.Msg("NPCAin/PILGRIM415_SQ_08_1/tie/1");
		await dialog.Msg("PILGRIM415_SQ_08_succ2");
		await Task.Delay(500);
		await dialog.Msg("PILGRIM415_SQ_08_succ3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

