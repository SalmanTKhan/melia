//--- Melia Script -----------------------------------------------------------
// Avoiding the Petrifying Frost
//--- Description -----------------------------------------------------------
// Quest to Look at the Petrification Detector.
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

[QuestScript(40780)]
public class Quest40780Script : QuestScript
{
	protected override void Load()
	{
		SetId(40780);
		SetName("Avoiding the Petrifying Frost");
		SetDescription("Look at the Petrification Detector");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_29_1_SQ_010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(204));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_FIRST_DETECTOR", "BeforeStart", BeforeStart);
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

