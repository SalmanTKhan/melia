//--- Melia Script -----------------------------------------------------------
// Positive Evidence (3)
//--- Description -----------------------------------------------------------
// Quest to Put the Goddess Statue on the magic circle at Tylila Path.
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

[QuestScript(40351)]
public class Quest40351Script : QuestScript
{
	protected override void Load()
	{
		SetId(40351);
		SetName("Positive Evidence (3)");
		SetDescription("Put the Goddess Statue on the magic circle at Tylila Path");

		AddPrerequisite(new LevelPrerequisite(89));
		AddPrerequisite(new CompletedPrerequisite("FARM47_2_SQ_080"));
		AddPrerequisite(new ItemPrerequisite("FARM47_2_SQ_080_ITEM_1", -100));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_MAGIC12", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JONARIS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FARM47_2_SQ_081_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

