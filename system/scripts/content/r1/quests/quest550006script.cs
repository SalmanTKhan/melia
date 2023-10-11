//--- Melia Script -----------------------------------------------------------
// [Hakkapeliter] Running Towards Death
//--- Description -----------------------------------------------------------
// Quest to Go to the Hackapell Master at Istora Ruins.
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

[QuestScript(550006)]
public class Quest550006Script : QuestScript
{
	protected override void Load()
	{
		SetId(550006);
		SetName("[Hakkapeliter] Running Towards Death");
		SetDescription("Go to the Hackapell Master at Istora Ruins");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("HACKAPELL_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("HACKAPELL_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char5_17_PRE2_DLG1", "UQ_Char5_17_PRE2", "I'm inevitable", "Cherish yourself"))
		{
			case 1:
				// Func/SCR_SET_UNLOCK_AOBJ_UNLOCK/UQ_Char5_17_PRE2_DLG1_1;
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
		await dialog.Msg("UQ_Char5_17_PRE2_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

