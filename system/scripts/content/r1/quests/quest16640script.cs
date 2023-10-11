//--- Melia Script -----------------------------------------------------------
// Destroyed Seal Tower (2)
//--- Description -----------------------------------------------------------
// Quest to Restore the goddess' powers to Rankis Seal Tower and Ranka Seal Tower.
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

[QuestScript(16640)]
public class Quest16640Script : QuestScript
{
	protected override void Load()
	{
		SetId(16640);
		SetName("Destroyed Seal Tower (2)");
		SetDescription("Restore the goddess' powers to Rankis Seal Tower and Ranka Seal Tower");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "SIAULIAI_46_1_MQ_05_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(169));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_04"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 118));
		AddReward(new ItemReward("Vis", 50700));

		AddDialogHook("SIAULIAI_46_1_DEADTREE02", "BeforeStart", BeforeStart);
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

