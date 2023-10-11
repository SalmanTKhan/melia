//--- Melia Script -----------------------------------------------------------
// [Engineer] Self Made Creation
//--- Description -----------------------------------------------------------
// Quest to Talk to the Engineer Master at Orsha.
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

[QuestScript(550015)]
public class Quest550015Script : QuestScript
{
	protected override void Load()
	{
		SetId(550015);
		SetName("[Engineer] Self Made Creation");
		SetDescription("Talk to the Engineer Master at Orsha");

		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("MASTER_ENG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ENG_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char3_23_PRE1_DLG1", "UQ_Char3_23_PRE1", "Interested.", "Tell her that's not your thing."))
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
		await dialog.Msg("UQ_Char3_23_PRE1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

