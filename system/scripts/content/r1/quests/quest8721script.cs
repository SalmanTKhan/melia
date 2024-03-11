//--- Melia Script -----------------------------------------------------------
// In the Palm of the Hand [Scout Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Scout Master.
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

[QuestScript(8721)]
public class Quest8721Script : QuestScript
{
	protected override void Load()
	{
		SetId(8721);
		SetName("In the Palm of the Hand [Scout Advancement]");
		SetDescription("Go to the Scout Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SCOUT3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SCOUT4_1_01", "JOB_SCOUT4_1", "I'll take on the assignment", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("JOB_SCOUT4_1_D");
				await dialog.Msg("JOB_SCOUT4_1_01_AG");
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

		await dialog.Msg("JOB_SCOUT4_1_03");
		dialog.HideNPC("JOB_SCOUT4_1_D");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

