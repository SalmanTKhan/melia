//--- Melia Script -----------------------------------------------------------
// Church Underground Passage
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Tomas.
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

[QuestScript(8522)]
public class Quest8522Script : QuestScript
{
	protected override void Load()
	{
		SetId(8522);
		SetName("Church Underground Passage");
		SetDescription("Talk to Follower Tomas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE575_MQ_04_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(40));
		AddPrerequisite(new CompletedPrerequisite("GELE574_MQ_09"));

		AddObjective("kill0", "Kill 1 Unknocker", new KillObjective(1, MonsterId.Boss_Unknocker));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_TOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_TOMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_04_01", "CHAPLE575_MQ_04", "I'm ready", "I can't believe it"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CHAPLE575_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

