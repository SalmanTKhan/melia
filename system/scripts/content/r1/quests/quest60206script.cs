//--- Melia Script -----------------------------------------------------------
// Back in time(7)
//--- Description -----------------------------------------------------------
// Quest to Check the Kaleidoscope of Time.
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

[QuestScript(60206)]
public class Quest60206Script : QuestScript
{
	protected override void Load()
	{
		SetId(60206);
		SetName("Back in time(7)");
		SetDescription("Check the Kaleidoscope of Time");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FIRETOWER691_MQ_5_TRACK", "boss_a");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_MQ_4"));

		AddObjective("kill0", "Kill 1 Turtai", new KillObjective(1, MonsterId.Boss_Turtai_Q1));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14168));

		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FIRETOWER691_MQ_5_3");
		dialog.ShowHelp("TUTO_PAST_FANTASYLIBRARY");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

