//--- Melia Script -----------------------------------------------------------
// Perfect Holy water [Cleric Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cleric Master.
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

[QuestScript(1115)]
public class Quest1115Script : QuestScript
{
	protected override void Load()
	{
		SetId(1115);
		SetName("Perfect Holy water [Cleric Advancement] (1)");
		SetDescription("Talk to the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("JOB_CLERIC2_1_ITEM3", 1));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CLERIC2_1_select1", "JOB_CLERIC2_1", "I'll treat the patients", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_CLERIC2_1_prog_startnpc");
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

		await dialog.Msg("JOB_CLERIC2_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

