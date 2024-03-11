//--- Melia Script -----------------------------------------------------------
// The Injured Herbalist (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Tales.
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

[QuestScript(50096)]
public class Quest50096Script : QuestScript
{
	protected override void Load()
	{
		SetId(50096);
		SetName("The Injured Herbalist (1)");
		SetDescription("Talk to Herbalist Tales");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_SQ030_statnpc01", "BRACKEN_63_1_SQ030", "I'll go and find the herbs", "Go back to the village soon"))
		{
			case 1:
				await dialog.Msg("BRACKEN_63_1_SQ030_AG");
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

