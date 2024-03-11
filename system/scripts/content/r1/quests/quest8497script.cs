//--- Melia Script -----------------------------------------------------------
// Helgasercle Invading the Tower
//--- Description -----------------------------------------------------------
// Quest to Find Helgasercle.
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

[QuestScript(8497)]
public class Quest8497Script : QuestScript
{
	protected override void Load()
	{
		SetId(8497);
		SetName("Helgasercle Invading the Tower");
		SetDescription("Find Helgasercle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_MQ_05_TRACK", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_01"), new CompletedPrerequisite("FTOWER45_MQ_02"), new CompletedPrerequisite("FTOWER45_MQ_03"), new CompletedPrerequisite("FTOWER45_MQ_04"));

		AddObjective("kill0", "Kill 1 Helgasercle", new KillObjective(1, MonsterId.Boss_Helgasercle));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Drug_AddStat", 1));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_MQ_05_E", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

