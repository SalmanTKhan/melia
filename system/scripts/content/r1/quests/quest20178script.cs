//--- Melia Script -----------------------------------------------------------
// One Step Closer to the King's Legacy
//--- Description -----------------------------------------------------------
// Quest to Defeat the monsters.
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

[QuestScript(20178)]
public class Quest20178Script : QuestScript
{
	protected override void Load()
	{
		SetId(20178);
		SetName("One Step Closer to the King's Legacy");
		SetDescription("Defeat the monsters");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS27_MQ_6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_MQ_5"));

		AddObjective("kill0", "Kill 10 Sauga(s) or Ticen(s) or Tucen(s) or Loftlem(s)", new KillObjective(10, 401001, 57045, 57046, 57041));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 19095));

		AddDialogHook("ROKAS27_MQ5BOX", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_REXITHER_1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ROKAS27_MQ_5_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

