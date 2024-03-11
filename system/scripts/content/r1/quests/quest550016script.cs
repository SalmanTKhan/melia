//--- Melia Script -----------------------------------------------------------
// [Engineer] Taking a Step Further
//--- Description -----------------------------------------------------------
// Quest to Talk to the Engineer Master at Orsha.
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

[QuestScript(550016)]
public class Quest550016Script : QuestScript
{
	protected override void Load()
	{
		SetId(550016);
		SetName("[Engineer] Taking a Step Further");
		SetDescription("Talk to the Engineer Master at Orsha");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_ENG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ENG_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char3_23_PRE2_DLG1", "UQ_Char3_23_PRE2", "I will take the task.", "I don't do boring stuff."))
		{
			case 1:
				// Func/SCR_SET_UNLOCK_AOBJ_UNLOCK;
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

		// Func/SCR_SET_UNLOCK_AOBJ_LOCK;
		await dialog.Msg("UQ_Char3_23_PRE2_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

