//--- Melia Script -----------------------------------------------------------
// Imminent Invasion
//--- Description -----------------------------------------------------------
// Quest to Meet the Paladin Master.
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

[QuestScript(17200)]
public class Quest17200Script : QuestScript
{
	protected override void Load()
	{
		SetId(17200);
		SetName("Imminent Invasion");
		SetDescription("Meet the Paladin Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE572_MQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(29));
		AddPrerequisite(new CompletedPrerequisite("CMINE6_TO_KATYN7_3"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("GELE572_MQ_01", "BeforeStart", BeforeStart);
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

