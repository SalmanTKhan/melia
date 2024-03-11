//--- Melia Script -----------------------------------------------------------
// Reception Error [Oracle Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Oracle Master.
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

[QuestScript(30048)]
public class Quest30048Script : QuestScript
{
	protected override void Load()
	{
		SetId(30048);
		SetName("Reception Error [Oracle Advancement]");
		SetDescription("Talk to the Oracle Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_ORACLE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ORACLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ORACLE_6_1_select", "JOB_ORACLE_6_1", "I will resolve it", "I need some time to think"))
		{
			case 1:
				await dialog.Msg("JOB_ORACLE_6_1_agree");
				dialog.HideNPC("JOB_ORACLE_6_1_OBJ1");
				dialog.HideNPC("JOB_ORACLE_6_1_OBJ2");
				dialog.HideNPC("JOB_ORACLE_6_1_OBJ3");
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

		await dialog.Msg("JOB_ORACLE_6_1_succ");
		dialog.HideNPC("JOB_ORACLE_6_1_OBJ1");
		dialog.HideNPC("JOB_ORACLE_6_1_OBJ2");
		dialog.HideNPC("JOB_ORACLE_6_1_OBJ3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

