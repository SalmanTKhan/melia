//--- Melia Script -----------------------------------------------------------
// [Hwarang] The Verity of Appreciating Arts 
//--- Description -----------------------------------------------------------
// Quest to Go to the Hwarang Master at Orsha.
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

[QuestScript(550005)]
public class Quest550005Script : QuestScript
{
	protected override void Load()
	{
		SetId(550005);
		SetName("[Hwarang] The Verity of Appreciating Arts ");
		SetDescription("Go to the Hwarang Master at Orsha");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_HWARANG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HWARANG_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char3_22_PRE2_DLG1", "UQ_Char3_22_PRE2", "Ask for a chance to prove yourself.", "Say that the evaluation of others is not necessary."))
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
		await dialog.Msg("UQ_Char3_22_PRE2_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

