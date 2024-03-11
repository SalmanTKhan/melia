//--- Melia Script -----------------------------------------------------------
// Mercenary Post Receptionist
//--- Description -----------------------------------------------------------
// Quest to Check for requests at Klaipeda's Mercenary Post. .
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

[QuestScript(7)]
public class Quest7Script : QuestScript
{
	protected override void Load()
	{
		SetId(7);
		SetName("Mercenary Post Receptionist");
		SetDescription("Check for requests at Klaipeda's Mercenary Post. ");

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("DROPITEM_REQUEST1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("DROPITEM_REQUEST1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DROPITEM_REQUEST1_dlg1", "DROPITEM_REQUEST1", "Accept the mission", "I won't accept the mission since I'm busy"))
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

		await dialog.Msg("DROPITEM_REQUEST1_succ1");
		// Func/SCR_DROPITEM_REQUEST1_NPC_QUEST_REWARD_RANK_RESET;
		// Func/TX_SCR_UQ_ACHIEVE_ADD_QUEST/UQ_Char1_23_PRE2/UQ_Char1_23_Unlock_Costume_5/1/Char1_23;
		// Func/TX_SCR_UQ_ACHIEVE_ADD_QUEST/UQ_Char1_24_PRE2/UQ_Char1_24_Unlock_Costume_2/1/Char1_24;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

