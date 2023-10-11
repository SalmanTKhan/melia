//--- Melia Script -----------------------------------------------------------
// Nobody Expects the Inquisition (3)
//--- Description -----------------------------------------------------------
// Quest to Drive Away the Heretics At Tymeris Temple.
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

[QuestScript(90093)]
public class Quest90093Script : QuestScript
{
	protected override void Load()
	{
		SetId(90093);
		SetName("Nobody Expects the Inquisition (3)");
		SetDescription("Drive Away the Heretics At Tymeris Temple");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CATACOMB_25_4_SQ_110_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_100"));

		AddObjective("kill0", "Kill 10 Yellow Pag Clamper(s)", new KillObjective(10, MonsterId.Pagclamper_Yellow));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_110", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_LAIMIS", "BeforeEnd", BeforeEnd);
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

		//SCR_CATACOMB_25_4_SQ_110_END
		await dialog.Msg("CATACOMB_25_4_SQ_110_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

