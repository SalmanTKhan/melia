//--- Melia Script -----------------------------------------------------------
// Knowledge of the Wizard [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Thaumaturge Master.
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

[QuestScript(1156)]
public class Quest1156Script : QuestScript
{
	protected override void Load()
	{
		SetId(1156);
		SetName("Knowledge of the Wizard [Thaumaturge Advancement]");
		SetDescription("Talk with the Thaumaturge Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_THAUMATURGE3_1_select1", "JOB_THAUMATURGE3_1", "What is the favor?", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_THAUMATURGE3_1_agree1");
				dialog.UnHideNPC("JOB_THAUMATURGE3_1_PAPER1");
				dialog.UnHideNPC("JOB_THAUMATURGE3_1_PAPER2");
				dialog.UnHideNPC("JOB_THAUMATURGE3_1_PAPER3");
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

		await dialog.Msg("JOB_THAUMATURGE3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

