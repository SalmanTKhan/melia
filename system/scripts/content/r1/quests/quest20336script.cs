//--- Melia Script -----------------------------------------------------------
// The Secret at the End
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20336)]
public class Quest20336Script : QuestScript
{
	protected override void Load()
	{
		SetId(20336);
		SetName("The Secret at the End");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ06"));

		AddReward(new ExpReward(2916304, 2916304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Vis", 49010));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeEnd", BeforeEnd);
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

		// Func/CHATHEDRAL56_MQ08_TRACK_PLAY;
		dialog.UnHideNPC("CHATHEDRAL56_MQ08_POTAL");
		dialog.UnHideNPC("CHATHEDRAL54_PART03_BISHOP");
		dialog.UnHideNPC("CHATHEDRAL56_MQ_BISHOP_AFTER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

