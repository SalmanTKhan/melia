//--- Melia Script -----------------------------------------------------------
// What Must Be Done (3)
//--- Description -----------------------------------------------------------
// Quest to Disarm the Secret Device at the Execution Grounds.
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

[QuestScript(30190)]
public class Quest30190Script : QuestScript
{
	protected override void Load()
	{
		SetId(30190);
		SetName("What Must Be Done (3)");
		SetDescription("Disarm the Secret Device at the Execution Grounds");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_6"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("PRISON_82_MQ_7_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_OBJ_6", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_OBJ_6", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("NPCAin/PRISON_82_OBJ_6/OPEN/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

