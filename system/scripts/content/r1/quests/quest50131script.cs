//--- Melia Script -----------------------------------------------------------
// The Experiment (3)
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

[QuestScript(50131)]
public class Quest50131Script : QuestScript
{
	protected override void Load()
	{
		SetId(50131);
		SetName("The Experiment (3)");
		SetDescription("Talk to Experiment Victim Hilbeth");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_SQ020"));

		AddObjective("kill0", "Kill 6 Magic Stabilizing Device (s) or Magic Valve(s)", new KillObjective(6, 153063, 153065));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_2_SQ030_startnpc01", "ABBAY_64_2_SQ030", "Destroy the testing facilities", "Go back to the village"))
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

