//--- Melia Script -----------------------------------------------------------
// Corrupted Mausoleum (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(8382)]
public class Quest8382Script : QuestScript
{
	protected override void Load()
	{
		SetId(8382);
		SetName("Corrupted Mausoleum (2)");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA3F_MQ_04_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(89));
		AddPrerequisite(new CompletedPrerequisite("ZACHA3F_MQ_01"));

		AddObjective("kill0", "Kill 1 Denoptic", new KillObjective(1, MonsterId.Boss_Denoptic_Q1));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 77));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("ZACHA3F_MQ_01_BLACKMAN_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA3F_MQ_04_01", "ZACHA3F_MQ_04", "Defeat Denoptic", "I'll wait a little bit"))
		{
			case 1:
				await dialog.Msg("ZACHA3F_MQ_04_AFST");
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("ZACHA3F_MQ_01_BLACKMAN_04");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

