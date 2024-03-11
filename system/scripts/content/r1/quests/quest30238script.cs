//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (8)
//--- Description -----------------------------------------------------------
// Quest to Check the Flamethrowing Magic Stone.
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

[QuestScript(30238)]
public class Quest30238Script : QuestScript
{
	protected override void Load()
	{
		SetId(30238);
		SetName("Inspect Inner Wall District 9 (8)");
		SetDescription("Check the Flamethrowing Magic Stone");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_7"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_OBJ_6", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_OBJ_6", "BeforeEnd", BeforeEnd);
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

		dialog.UnHideNPC("CASTLE_20_2_OBJ_6_EFFECT");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The flame erupts from the Flamethrowing Magic Stone");
		await Task.Delay(2000);
		// Func/SCR_CASTLE_20_2_SQ_CLUE_RUN/4;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

