//--- Melia Script -----------------------------------------------------------
// In the Deep Forest [Hackapell Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hackapell Master.
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

[QuestScript(90163)]
public class Quest90163Script : QuestScript
{
	protected override void Load()
	{
		SetId(90163);
		SetName("In the Deep Forest [Hackapell Advancement]");
		SetDescription("Talk to the Hackapell Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("HACKAPELL_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("HACKAPELL_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HACKAPELL_8_1_ST", "JOB_HACKAPELL_8_1", "Leave it up to me.", "I will think about it"))
		{
			case 1:
				await dialog.Msg("JOB_HACKAPELL_8_1_AG");
				dialog.UnHideNPC("JOB_HACKAPELL_8_1_OBJ");
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

		await dialog.Msg("JOB_HACKAPELL_8_1_SU");
		dialog.HideNPC("JOB_HACKAPELL_8_1_OBJ");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "If you don't have a Velheider, you can adopt one for free at the Companion Trader!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

