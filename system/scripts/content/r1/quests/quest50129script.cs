//--- Melia Script -----------------------------------------------------------
// The Experiment (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Experiment Victim Hilbeth.
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

[QuestScript(50129)]
public class Quest50129Script : QuestScript
{
	protected override void Load()
	{
		SetId(50129);
		SetName("The Experiment (1)");
		SetDescription("Talk to Experiment Victim Hilbeth");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_2_SQ010_startnpc01", "ABBAY_64_2_SQ010", "I'll find the backpack for you", "I'm sorry"))
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


		return HookResult.Break;
	}
}

