//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow [Hunter Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Master.
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

[QuestScript(1086)]
public class Quest1086Script : QuestScript
{
	protected override void Load()
	{
		SetId(1086);
		SetName("Dream Book of the Bow [Hunter Advancement] (4)");
		SetDescription("Talk to the Hunter Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_HUNTER2_3"));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER2_4_select1", "JOB_HUNTER2_4", "I'll deliver the pouch", "Decline"))
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

		await dialog.Msg("JOB_HUNTER1_succ1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "If you don't have a Velheider, you can adopt one for free at the Companion Trader!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

