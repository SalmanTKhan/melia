//--- Melia Script -----------------------------------------------------------
// The power that was prepared for the future
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elgos Abbot.
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

[QuestScript(80098)]
public class Quest80098Script : QuestScript
{
	protected override void Load()
	{
		SetId(80098);
		SetName("The power that was prepared for the future");
		SetDescription("Talk to the Elgos Abbot");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_8"));

		AddObjective("kill0", "Kill 9 Brown Harugal(s) or Green Hohen Orben(s) or Brown Hohen Mane(s)", new KillObjective(9, 57980, 57976, 57968));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_10_start", "ABBEY_35_4_SQ_10", "Alright, I'll help you", "I'm busy now"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_4_SQ_10_AG");
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

		await dialog.Msg("ABBEY_35_4_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

