//--- Melia Script -----------------------------------------------------------
// The Resentful Soldier's Spirit (1)
//--- Description -----------------------------------------------------------
// Quest to Examine the Soldier's Grave.
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

[QuestScript(50070)]
public class Quest50070Script : QuestScript
{
	protected override void Load()
	{
		SetId(50070);
		SetName("The Resentful Soldier's Spirit (1)");
		SetDescription("Examine the Soldier's Grave");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_67_SQ020_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(207));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter_Q3));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("UNDER67_SQ020", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER67_SQ030", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("UNDER_67_SQ020_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

