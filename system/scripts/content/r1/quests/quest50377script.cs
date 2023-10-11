//--- Melia Script -----------------------------------------------------------
// The Sculpture in Magic Shop District
//--- Description -----------------------------------------------------------
// Quest to Use the Magic Block on the Sculptures in the Magic Shop District.
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

[QuestScript(50377)]
public class Quest50377Script : QuestScript
{
	protected override void Load()
	{
		SetId(50377);
		SetName("The Sculpture in Magic Shop District");
		SetDescription("Use the Magic Block on the Sculptures in the Magic Shop District");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_NICOPOLIS_81_1_SQ_01_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02"));

		AddObjective("kill0", "Kill 10 Mimorat Purple(s) or Mimorat Green(s)", new KillObjective(10, 59156, 59159));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 24000));

		AddDialogHook("NICO811_DEVICE1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_DEVICE1", "BeforeEnd", BeforeEnd);
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

