//--- Melia Script -----------------------------------------------------------
// Who am I(2)
//--- Description -----------------------------------------------------------
// Quest to Activate the Secret Device in the Hanging Room.
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

[QuestScript(30165)]
public class Quest30165Script : QuestScript
{
	protected override void Load()
	{
		SetId(30165);
		SetName("Who am I(2)");
		SetDescription("Activate the Secret Device in the Hanging Room");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_1"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_OBJ_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_1", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_PRISON_80_MQ_2_SUCC;
		await dialog.Msg("PRISON_80_MQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

