//--- Melia Script -----------------------------------------------------------
// An Exhausted Body (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Experiment Victim Tilis.
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

[QuestScript(50122)]
public class Quest50122Script : QuestScript
{
	protected override void Load()
	{
		SetId(50122);
		SetName("An Exhausted Body (1)");
		SetDescription("Talk to Experiment Victim Tilis");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_SQ010_startnpc01", "ABBAY_64_1_SQ010", "Do you have a Stamina recovery potion?", "It's best to get out of the monastery and get treatment"))
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

