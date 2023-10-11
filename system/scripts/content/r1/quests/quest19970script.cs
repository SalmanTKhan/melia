//--- Melia Script -----------------------------------------------------------
// Secret of the Unusual Place
//--- Description -----------------------------------------------------------
// Quest to Hidden Area.
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

[QuestScript(19970)]
public class Quest19970Script : QuestScript
{
	protected override void Load()
	{
		SetId(19970);
		SetName("Secret of the Unusual Place");
		SetDescription("Hidden Area");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM52_SQ_110_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("kill0", "Kill 1 Velorchard", new KillObjective(1, MonsterId.Boss_Velorchard_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_BOX", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("NPCAin/PILGRIM52_BOX/OPENSTD/0");
		await Task.Delay(2000);
		dialog.HideNPC("PILGRIM52_BOX");
		await dialog.Msg("FadeOutIN/2000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

