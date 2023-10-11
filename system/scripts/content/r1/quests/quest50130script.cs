//--- Melia Script -----------------------------------------------------------
// The Experiment (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Experiment Victim Hilbeth.
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

[QuestScript(50130)]
public class Quest50130Script : QuestScript
{
	protected override void Load()
	{
		SetId(50130);
		SetName("The Experiment (2)");
		SetDescription("Talk to Experiment Victim Hilbeth");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_SQ010"));

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

		switch (await dialog.Select("ABBAY_64_2_SQ020_startnpc01", "ABBAY_64_2_SQ020", "You stay put; I'll do it for you", "Getting some rest first will be better"))
		{
			case 1:
				await dialog.Msg("ABBAY_64_2_SQ020_startnpc02");
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

