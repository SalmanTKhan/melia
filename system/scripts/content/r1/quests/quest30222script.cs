//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (3)
//--- Description -----------------------------------------------------------
// Quest to Check the magic circle in the central control room.
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

[QuestScript(30222)]
public class Quest30222Script : QuestScript
{
	protected override void Load()
	{
		SetId(30222);
		SetName("Investigate Inner Wall District 8 (3)");
		SetDescription("Check the magic circle in the central control room");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_3_SQ_4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_3"));

		AddObjective("kill0", "Kill 8 Akhlass Dame(s)", new KillObjective(8, MonsterId.Aklasdame));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_OBJ_7", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_OBJ_7", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "The magic circle is destroyed so there is no way of knowing.{nl}Like it is said on the Inner Wall District 8 Management manual. Find the magical eye.");
		// Func/SCR_CASTLE_20_3_SQ_4_SUCC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

