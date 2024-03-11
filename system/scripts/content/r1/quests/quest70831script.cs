//--- Melia Script -----------------------------------------------------------
// It was not an easy opponent
//--- Description -----------------------------------------------------------
// Quest to Follow the two lords.
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

[QuestScript(70831)]
public class Quest70831Script : QuestScript
{
	protected override void Load()
	{
		SetId(70831);
		SetName("It was not an easy opponent");
		SetDescription("Follow the two lords");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "MAPLE23_2_SQ12_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ11"));

		AddObjective("kill0", "Kill 10 Red Colimen(s) or Yellow Caro(s)", new KillObjective(10, 58482, 58483));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 146740));

		AddDialogHook("MAPLE232_SQ_12", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_13_1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("MAPLE232_SQ_12_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

