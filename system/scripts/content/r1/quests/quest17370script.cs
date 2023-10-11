//--- Melia Script -----------------------------------------------------------
// Endless Purification [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Priest Master.
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

[QuestScript(17370)]
public class Quest17370Script : QuestScript
{
	protected override void Load()
	{
		SetId(17370);
		SetName("Endless Purification [Priest Advancement]");
		SetDescription("Meet the Priest Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PRIEST4_1_ST", "JOB_PRIEST4_1", "I will go and purify the evil energy", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_PRIEST4_1_AC");
				dialog.UnHideNPC("JOB_PRIEST4_1");
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

		await dialog.Msg("JOB_PRIEST4_1_COMP");
		dialog.HideNPC("JOB_PRIEST4_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

