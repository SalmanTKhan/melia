//--- Melia Script -----------------------------------------------------------
// Through the front door
//--- Description -----------------------------------------------------------
// Quest to Disarm Grinende's Magic Circle.
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

[QuestScript(30170)]
public class Quest30170Script : QuestScript
{
	protected override void Load()
	{
		SetId(30170);
		SetName("Through the front door");
		SetDescription("Disarm Grinende's Magic Circle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON_80_MQ_7_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_6"));
		AddPrerequisite(new ItemPrerequisite("PRISON_80_MQ_3_ITEM", -100));

		AddObjective("kill0", "Kill 1 Grinender", new KillObjective(1, MonsterId.Boss_Grinender_Q1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_OBJ_4", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PRISON_80_MQ_7_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

