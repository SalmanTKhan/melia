//--- Melia Script -----------------------------------------------------------
// Solitary Cell Barrier
//--- Description -----------------------------------------------------------
// Quest to Release the Demon Barrier.
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

[QuestScript(30173)]
public class Quest30173Script : QuestScript
{
	protected override void Load()
	{
		SetId(30173);
		SetName("Solitary Cell Barrier");
		SetDescription("Release the Demon Barrier");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "PRISON_80_MQ_10_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_9"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));

		AddDialogHook("PRISON_80_MQ_10_TRIGGER", "BeforeStart", BeforeStart);
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

