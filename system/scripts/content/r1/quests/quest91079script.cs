//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (8)
//--- Description -----------------------------------------------------------
// Quest to Chasing Beholder.
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

[QuestScript(91079)]
public class Quest91079Script : QuestScript
{
	protected override void Load()
	{
		SetId(91079);
		SetName("Chasing the Preacher (8)");
		SetDescription("Chasing Beholder");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON1_MQ_8_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_7"));

		AddObjective("kill0", "Kill 33 Banshee Without Ego(s) or Vubbe Guard(s) or Vubbe Squad(s)", new KillObjective(33, 59666, 59665, 59667));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_8", "BeforeStart", BeforeStart);
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

