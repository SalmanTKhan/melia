//--- Melia Script -----------------------------------------------------------
// Hunter's Test [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Submaster.
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

[QuestScript(30099)]
public class Quest30099Script : QuestScript
{
	protected override void Load()
	{
		SetId(30099);
		SetName("Hunter's Test [Hunter Advancement]");
		SetDescription("Talk to the Hunter Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HUNTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HUNTER_4_1_select", "JOB_2_HUNTER_4_1", "I'll give it a try", "That seems difficult"))
		{
			case 1:
				await dialog.Msg("JOB_2_HUNTER_4_1_agree");
				dialog.UnHideNPC("JOB_2_HUNTER_4_1_BOX_1");
				dialog.UnHideNPC("JOB_2_HUNTER_4_1_BOX_2");
				dialog.UnHideNPC("JOB_2_HUNTER_4_1_BOX_3");
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

		await dialog.Msg("JOB_2_HUNTER_4_1_succ");
		dialog.HideNPC("JOB_2_HUNTER_4_1_BOX_1");
		dialog.HideNPC("JOB_2_HUNTER_4_1_BOX_2");
		dialog.HideNPC("JOB_2_HUNTER_4_1_BOX_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

