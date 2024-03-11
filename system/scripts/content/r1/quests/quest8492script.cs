//--- Melia Script -----------------------------------------------------------
// Mage Tower 4th Floor (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8492)]
public class Quest8492Script : QuestScript
{
	protected override void Load()
	{
		SetId(8492);
		SetName("Mage Tower 4th Floor (5)");
		SetDescription("Talk to Grita");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER44_MQ_05_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_MQ_04"));

		AddObjective("kill0", "Kill 1 Grinender", new KillObjective(1, MonsterId.Boss_Grinender));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("TreasureboxKey3", 1));
		AddReward(new ItemReward("Vis", 30750));

		AddDialogHook("FTOWER44_GRITA_REMAIN", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_MQ_05_01", "FTOWER44_MQ_05", "I will go to the goddess", "Tell him its too dangerous"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

