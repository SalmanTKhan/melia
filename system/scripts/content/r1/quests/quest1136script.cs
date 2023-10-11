//--- Melia Script -----------------------------------------------------------
// Guardian of Fedimian [Wizard Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(1136)]
public class Quest1136Script : QuestScript
{
	protected override void Load()
	{
		SetId(1136);
		SetName("Guardian of Fedimian [Wizard Advancement] (2)");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_WIZARD3_1"));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WIZARD3_2_select1", "JOB_WIZARD3_2", "I will go and use the scroll to collect data", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_WIZARD3_2_prog1");
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

		await dialog.Msg("JOB_WIZARD3_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

