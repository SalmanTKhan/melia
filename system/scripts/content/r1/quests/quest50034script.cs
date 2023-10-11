//--- Melia Script -----------------------------------------------------------
// The Disappearance (2)
//--- Description -----------------------------------------------------------
// Quest to Search the spot where the disappearances took place.
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

[QuestScript(50034)]
public class Quest50034Script : QuestScript
{
	protected override void Load()
	{
		SetId(50034);
		SetName("The Disappearance (2)");
		SetDescription("Search the spot where the disappearances took place");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_040_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_040"));

		AddObjective("kill0", "Kill 6 Paladin Follower A1(s) or Paladin Follower A3(s)", new KillObjective(6, 11281, 11283));

		AddDialogHook("PARTY_Q41_ORB", "BeforeStart", BeforeStart);
		AddDialogHook("KLAIPEDA_MAYER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PARTY_Q_041_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

