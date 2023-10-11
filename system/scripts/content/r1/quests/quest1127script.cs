//--- Melia Script -----------------------------------------------------------
// Careful Move [Sapper Advancement](2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(1127)]
public class Quest1127Script : QuestScript
{
	protected override void Load()
	{
		SetId(1127);
		SetName("Careful Move [Sapper Advancement](2)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("JOB_SAPPER3_1"));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SAPPER3_2_select1", "JOB_SAPPER3_2", "I will go and do the test", "Decline"))
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

		await dialog.Msg("JOB_SAPPER3_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

