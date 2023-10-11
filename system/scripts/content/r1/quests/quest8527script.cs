//--- Melia Script -----------------------------------------------------------
// Beyond the Darkness
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidas.
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

[QuestScript(8527)]
public class Quest8527Script : QuestScript
{
	protected override void Load()
	{
		SetId(8527);
		SetName("Beyond the Darkness");
		SetDescription("Talk to Follower Vaidas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE575_MQ_09_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(40));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_04"));

		AddObjective("kill0", "Kill 1 Cyclops", new KillObjective(1, MonsterId.Boss_Strongholder_Q1));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("CHAPEL_VIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE575_MQ_09", "CHAPLE575_MQ_09", "I will go to the 1st floor", "Look for another way"))
		{
			case 1:
				dialog.UnHideNPC("CHAPLE575_MQ_09");
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

		await dialog.Msg("CHAPLE575_MQ_09_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

