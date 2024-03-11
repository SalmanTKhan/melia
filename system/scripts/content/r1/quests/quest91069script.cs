//--- Melia Script -----------------------------------------------------------
// Join
//--- Description -----------------------------------------------------------
// Quest to Join Pajauta.
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

[QuestScript(91069)]
public class Quest91069Script : QuestScript
{
	protected override void Load()
	{
		SetId(91069);
		SetName("Join");
		SetDescription("Join Pajauta");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON3_MQ_6_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_2_3_4_5"));

		AddObjective("kill0", "Kill 36 Wendigo Subject(s) or Lunatic Wendigo(s) or Dumaro Subject(s)", new KillObjective(36, 59663, 59662, 59664));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_3", "BeforeStart", BeforeStart);
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

