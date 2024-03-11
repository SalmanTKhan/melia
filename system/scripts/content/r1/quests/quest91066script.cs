//--- Melia Script -----------------------------------------------------------
// To the Right (2)
//--- Description -----------------------------------------------------------
// Quest to Corner Lunatic Marnox to the next point.
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

[QuestScript(91066)]
public class Quest91066Script : QuestScript
{
	protected override void Load()
	{
		SetId(91066);
		SetName("To the Right (2)");
		SetDescription("Corner Lunatic Marnox to the next point");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_2_DPRISON3_MQ_3_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_2"));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_R_2", "BeforeStart", BeforeStart);
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

