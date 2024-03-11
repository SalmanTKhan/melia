//--- Melia Script -----------------------------------------------------------
// Hard Work does not Betray [Wizard Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(1114)]
public class Quest1114Script : QuestScript
{
	protected override void Load()
	{
		SetId(1114);
		SetName("Hard Work does not Betray [Wizard Advancement] (2)");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_WIZARD2_1"));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WIZARD2_2_select1", "JOB_WIZARD2_2", "I will go and use the scroll to collect data", "Decline"))
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

		await dialog.Msg("JOB_WIZARD2_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

