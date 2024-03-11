//--- Melia Script -----------------------------------------------------------
// Recapture the Bell Tower
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8529)]
public class Quest8529Script : QuestScript
{
	protected override void Load()
	{
		SetId(8529);
		SetName("Recapture the Bell Tower");
		SetDescription("Talk to Follower Algis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE577_MQ_02_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(48));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_01"));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 720));

		AddDialogHook("CHAPLE577_ARUNE_01", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE577_MQ_02_01", "CHAPLE577_MQ_02", "Begin immediately", "Gesti might still be around"))
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

		await dialog.Msg("CHAPLE577_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

