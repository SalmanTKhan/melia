//--- Melia Script -----------------------------------------------------------
// Guardian Destructors (3)
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

[QuestScript(8387)]
public class Quest8387Script : QuestScript
{
	protected override void Load()
	{
		SetId(8387);
		SetName("Guardian Destructors (3)");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA4F_MQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(92));
		AddPrerequisite(new CompletedPrerequisite("ZACHA4F_MQ_04"));

		AddObjective("kill0", "Kill 1 Bearkaras", new KillObjective(1, MonsterId.Boss_Bearkaras_Q2));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("misc_BRC03_105_2", 1));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ZACHA4F_MQ_05_BLACKMAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_MQ_05_01", "ZACHA4F_MQ_05", "Stop the last Guardian to prevent the Mausoleum from being destroyed", "Ignore"))
		{
			case 1:
				dialog.HideNPC("ZACHA4F_MQ_05_BLACKMAN");
				await dialog.Msg("FadeOutIN/2000");
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


		return HookResult.Break;
	}
}

