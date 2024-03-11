//--- Melia Script -----------------------------------------------------------
// Guilty Conscience (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(72131)]
public class Quest72131Script : QuestScript
{
	protected override void Load()
	{
		SetId(72131);
		SetName("Guilty Conscience (4)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("MASTER_SAPPER1_3"));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("JOB_SAPPER2_4_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

