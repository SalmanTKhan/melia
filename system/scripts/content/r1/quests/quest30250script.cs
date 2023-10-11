//--- Melia Script -----------------------------------------------------------
// Operation Outter Wall Core Retrieval (8)
//--- Description -----------------------------------------------------------
// Quest to Check the Outer Wall Core.
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

[QuestScript(30250)]
public class Quest30250Script : QuestScript
{
	protected override void Load()
	{
		SetId(30250);
		SetName("Operation Outter Wall Core Retrieval (8)");
		SetDescription("Check the Outer Wall Core");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_1_SQ_8_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_7"));

		AddObjective("kill0", "Kill 1 Gremlin", new KillObjective(1, MonsterId.Boss_Gremlin_Q1));

		AddReward(new ExpReward(7261044, 7261044));
		AddReward(new ItemReward("CASTLE_20_1_SQ_8_ITEM", 1));
		AddReward(new ItemReward("expCard13", 5));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_9", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_OBJ_9", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("CASTLE_20_1_OBJ_9")?.PlayEffectLocal(character.Connection, "F_pc_making_finish_white", 1.0f, "MID");
		dialog.HideNPC("CASTLE_20_1_OBJ_9");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired the Outer Wall Core.{nl}Return to Kupole Milda.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

