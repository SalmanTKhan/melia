//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (5)
//--- Description -----------------------------------------------------------
// Quest to Collect Blue Herbs.
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

[QuestScript(90014)]
public class Quest90014Script : QuestScript
{
	protected override void Load()
	{
		SetId(90014);
		SetName("Clear the Corruption (5)");
		SetDescription("Collect Blue Herbs");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_04"));

		AddReward(new ExpReward(491420, 491420));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

