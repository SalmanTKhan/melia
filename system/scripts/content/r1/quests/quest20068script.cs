//--- Melia Script -----------------------------------------------------------
// Defeat the attacking monsters
//--- Description -----------------------------------------------------------
// Quest to Look at the pothole.
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

[QuestScript(20068)]
public class Quest20068Script : QuestScript
{
	protected override void Load()
	{
		SetId(20068);
		SetName("Defeat the attacking monsters");
		SetDescription("Look at the pothole");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "KATYN13_1_KEY_SUB1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(112));

		AddObjective("kill0", "Kill 2 Green Pokuborn(s)", new KillObjective(2, MonsterId.Arburn_Pokubu_Green));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("food_018", 3));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_KEY_SUB1_TRUFFLE", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_KEY_SUB1_TRUFFLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You found a Truffle from the dug area!", 5);
		await Task.Delay(5000);
		dialog.HideNPC("KATYN13_1_KEY_SUB1_TRUFFLE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

