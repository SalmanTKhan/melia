//--- Melia Script -----------------------------------------------------------
// Showing True Colors(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Clark.
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

[QuestScript(70527)]
public class Quest70527Script : QuestScript
{
	protected override void Load()
	{
		SetId(70527);
		SetName("Showing True Colors(2)");
		SetDescription("Talk to Believer Clark");

		AddPrerequisite(new LevelPrerequisite(261));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ07"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM41_2_SQ07_S", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_07", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PILGRIM412_SQ_08_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

