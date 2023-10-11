//--- Melia Script -----------------------------------------------------------
// Long Dreams Are Dreamt at Narvas Temple (1)
//--- Description -----------------------------------------------------------
// Quest to Use the Warp Device.
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

[QuestScript(50368)]
public class Quest50368Script : QuestScript
{
	protected override void Load()
	{
		SetId(50368);
		SetName("Long Dreams Are Dreamt at Narvas Temple (1)");
		SetDescription("Use the Warp Device");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY22_5_SQ14_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ13"));

		AddObjective("kill0", "Kill 1 Demon Lord Hauberk", new KillObjective(1, MonsterId.Boss_Hauberk_Q1));

		AddReward(new ExpReward(131897408, 131897408));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("ABBEY22_5_SUBQ14_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_FLURRY5", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ABBEY22_5_SUBQ13_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

