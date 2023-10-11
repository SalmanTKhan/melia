//--- Melia Script -----------------------------------------------------------
// The Third Epitaph (2)
//--- Description -----------------------------------------------------------
// Quest to Burn down the vines that are binding the tombstone.
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

[QuestScript(40640)]
public class Quest40640Script : QuestScript
{
	protected override void Load()
	{
		SetId(40640);
		SetName("The Third Epitaph (2)");
		SetDescription("Burn down the vines that are binding the tombstone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS37_2_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_050"));

		AddObjective("kill0", "Kill 22 Lizardman Magician(s) or Minos(s) or Minos Archer(s)", new KillObjective(22, 57627, 41302, 57615));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("REMAINS37_2_VINE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT03", "BeforeEnd", BeforeEnd);
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

		await Task.Delay(300);
		await dialog.Msg("AITVARAS_RECORD_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

