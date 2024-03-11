//--- Melia Script -----------------------------------------------------------
// Monster Preying on Military Supplies (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Dennis.
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

[QuestScript(50017)]
public class Quest50017Script : QuestScript
{
	protected override void Load()
	{
		SetId(50017);
		SetName("Monster Preying on Military Supplies (1)");
		SetDescription("Talk to Soldier Dennis");

		AddPrerequisite(new LevelPrerequisite(71));

		AddObjective("kill0", "Kill 15 Black Ridimed(s) or Pink Chupaluka(s) or Orange Sakmoli(s)", new KillObjective(15, 400543, 57353, 400563));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1349));

		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_100_select01", "SIAULIAI_50_1_SQ_100", "I will defeat the monsters", "I'm busy"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_100_prog01");
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

		await dialog.Msg("SIAULIAI_50_1_SQ_100_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

