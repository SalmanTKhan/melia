//--- Melia Script -----------------------------------------------------------
// The Sculpture in Magija Empty Lot
//--- Description -----------------------------------------------------------
// Quest to Use the Magic Block on the Sculptures in the Magija Empty Lot.
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

[QuestScript(50379)]
public class Quest50379Script : QuestScript
{
	protected override void Load()
	{
		SetId(50379);
		SetName("The Sculpture in Magija Empty Lot");
		SetDescription("Use the Magic Block on the Sculptures in the Magija Empty Lot");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_1_SQ_02_3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 2));
		AddReward(new ItemReward("Vis", 25000));

		AddDialogHook("NICO811_DEVICE2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_DEVICE2", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}
}

