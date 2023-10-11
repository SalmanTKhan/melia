//--- Melia Script -----------------------------------------------------------
// The Injured Herbalist (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Cleric Submaster.
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

[QuestScript(50098)]
public class Quest50098Script : QuestScript
{
	protected override void Load()
	{
		SetId(50098);
		SetName("The Injured Herbalist (3)");
		SetDescription("Talk with Cleric Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_SQ040"));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_SQ050_startnpc01", "BRACKEN_63_1_SQ050", "Let's go back to Tales", "Tell him to wait a bit longer"))
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

