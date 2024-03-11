//--- Melia Script -----------------------------------------------------------
// Keepsake
//--- Description -----------------------------------------------------------
// Quest to Talk to Experiment Victim Fils.
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

[QuestScript(50124)]
public class Quest50124Script : QuestScript
{
	protected override void Load()
	{
		SetId(50124);
		SetName("Keepsake");
		SetDescription("Talk to Experiment Victim Fils");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Drug_SP1_Q", 45));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_PEAPLE02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_PEAPLE02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_SQ030_startnpc01", "ABBAY_64_1_SQ030", "I'll bring you those objects if I can find them", "First we need to get water"))
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

