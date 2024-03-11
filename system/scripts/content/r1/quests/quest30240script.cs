//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (10)
//--- Description -----------------------------------------------------------
// Quest to Check the secret storage chest in the command room.
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

[QuestScript(30240)]
public class Quest30240Script : QuestScript
{
	protected override void Load()
	{
		SetId(30240);
		SetName("Inspect Inner Wall District 9 (10)");
		SetDescription("Check the secret storage chest in the command room");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_9"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("CASTLE_20_2_SQ_10_ITEM_1", 1));
		AddReward(new ItemReward("CASTLE_20_2_SQ_10_ITEM_2", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_OBJ_8", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_OBJ_8", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've found two documents from the Secret Storage Chest.{nl}Read them and return to Kupole Liepa.");
		await dialog.Msg("NPCAin/CASTLE_20_2_OBJ_8/OPEN/1");
		dialog.UnHideNPC("CASTLE_20_2_NPC_1_AFTER");
		// Func/SCR_CASTLE_20_2_SQ_10_SUCC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

