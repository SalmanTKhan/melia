//--- Melia Script -----------------------------------------------------------
// Inspect the Perimeter (2)
//--- Description -----------------------------------------------------------
// Quest to Look around the Jonael Memorial.
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

[QuestScript(90141)]
public class Quest90141Script : QuestScript
{
	protected override void Load()
	{
		SetId(90141);
		SetName("Inspect the Perimeter (2)");
		SetDescription("Look around the Jonael Memorial");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_DCAPITAL_20_6_SQ_20_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(295));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_10"));

		AddDialogHook("DCAPITAL_20_6_SQ_10_ENT", "BeforeStart", BeforeStart);
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

