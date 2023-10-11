//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (4)
//--- Description -----------------------------------------------------------
// Quest to Chase the Beholder.
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

[QuestScript(91075)]
public class Quest91075Script : QuestScript
{
	protected override void Load()
	{
		SetId(91075);
		SetName("Chasing the Preacher (4)");
		SetDescription("Chase the Beholder");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON1_MQ_4_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_3"));

		AddObjective("kill0", "Kill 50 Vubbe Guard(s) or Vubbe Squad(s)", new KillObjective(50, 59665, 59667));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_4", "BeforeStart", BeforeStart);
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

