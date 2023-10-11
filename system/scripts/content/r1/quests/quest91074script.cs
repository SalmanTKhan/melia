//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (3)
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

[QuestScript(91074)]
public class Quest91074Script : QuestScript
{
	protected override void Load()
	{
		SetId(91074);
		SetName("Chasing the Preacher (3)");
		SetDescription("Chase the Beholder");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON1_MQ_3_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_2"));

		AddObjective("kill0", "Kill 30 Vubbe Guard(s)", new KillObjective(30, MonsterId.Episode13_2_Goblin_Brandingiron));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_3", "BeforeStart", BeforeStart);
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

