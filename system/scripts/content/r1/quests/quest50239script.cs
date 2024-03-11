//--- Melia Script -----------------------------------------------------------
// Cursed Keepsakes [Featherfoot Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Featherfoot Master.
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

[QuestScript(50239)]
public class Quest50239Script : QuestScript
{
	protected override void Load()
	{
		SetId(50239);
		SetName("Cursed Keepsakes [Featherfoot Advancement]");
		SetDescription("Talk with the Featherfoot Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("FEATHERFOOT_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("FEATHERFOOT_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FEATHERFOOT_8_1_START1", "JOB_FEATHERFOOT_8_1", "I'll retrieve it", "I will do something else."))
		{
			case 1:
				dialog.UnHideNPC("FEATHERFOOT_ORB_JOB_ITEM");
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

		await dialog.Msg("JOB_FEATHERFOOT_8_1_SUCC1");
		dialog.HideNPC("FEATHERFOOT_ORB_JOB_ITEM");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

