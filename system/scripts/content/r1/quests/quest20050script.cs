//--- Melia Script -----------------------------------------------------------
// Mysterious Slate (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Crystal Pillar in the Closed Area.
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

[QuestScript(20050)]
public class Quest20050Script : QuestScript
{
	protected override void Load()
	{
		SetId(20050);
		SetName("Mysterious Slate (1)");
		SetDescription("Check the Crystal Pillar in the Closed Area");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_3_BOSS_2boss", 4000);

		AddPrerequisite(new LevelPrerequisite(21));
		AddPrerequisite(new CompletedPrerequisite("MINE_3_RESQUE1"));

		AddReward(new ExpReward(67150, 67150));
		AddReward(new ItemReward("stonetablet01_noread", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 1764));

		AddDialogHook("CMINE6_TO_KATYN7_1_START", "BeforeStart", BeforeStart);
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

