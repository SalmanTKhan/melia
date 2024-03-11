//--- Melia Script -----------------------------------------------------------
// Being Considerate to Elders(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Jacob.
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

[QuestScript(70504)]
public class Quest70504Script : QuestScript
{
	protected override void Load()
	{
		SetId(70504);
		SetName("Being Considerate to Elders(3)");
		SetDescription("Talk to Pilgrim Jacob");

		AddPrerequisite(new LevelPrerequisite(258));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_1_SQ04"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_05_start", "PILGRIM41_1_SQ05", "Happily agree", "Say that you have more important things to do"))
		{
			case 1:
				// Func/SCR_PILGRIM411_SQ_05_P;
				await dialog.Msg("FadeOutIN/1000");
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

		await dialog.Msg("PILGRIM411_SQ_05_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

