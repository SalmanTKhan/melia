//--- Melia Script -----------------------------------------------------------
// Mysterious Wizard
//--- Description -----------------------------------------------------------
// Quest to Return to Rose and deliver the diary.
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

[QuestScript(50110)]
public class Quest50110Script : QuestScript
{
	protected override void Load()
	{
		SetId(50110);
		SetName("Mysterious Wizard");
		SetDescription("Return to Rose and deliver the diary");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN_63_3_MQ030_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_MQ020"));

		AddObjective("kill0", "Kill 15 Vubbe Warrior(s) or Lapasape Mage(s)", new KillObjective(15, 103024, 57640));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_ROZE_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_ROZE01", "BeforeEnd", BeforeEnd);
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

