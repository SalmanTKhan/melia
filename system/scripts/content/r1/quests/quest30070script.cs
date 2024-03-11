//--- Melia Script -----------------------------------------------------------
// Quick and Accurate [Fencer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Fencer Master.
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

[QuestScript(30070)]
public class Quest30070Script : QuestScript
{
	protected override void Load()
	{
		SetId(30070);
		SetName("Quick and Accurate [Fencer Advancement]");
		SetDescription("Talk with the Fencer Master");

		AddPrerequisite(new LevelPrerequisite(185));

		AddReward(new ItemReward("RAP01_103", 1));

		AddDialogHook("MASTER_FENCER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FENCER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FENCER_5_1_select", "JOB_FENCER_5_1", "I will take the test", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_FENCER_5_1_agree");
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

		await dialog.Msg("JOB_FENCER_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

