//--- Melia Script -----------------------------------------------------------
// Fishing on Land (2)
//--- Description -----------------------------------------------------------
// Quest to Hide behind a tree.
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

[QuestScript(9019)]
public class Quest9019Script : QuestScript
{
	protected override void Load()
	{
		SetId(9019);
		SetName("Fishing on Land (2)");
		SetDescription("Hide behind a tree");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS28_TRAP_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("ROKAS28_SET_TRAP"));

		AddObjective("kill0", "Kill 1 Ravinepede", new KillObjective(1, MonsterId.Boss_Ravinepede));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("FOOT02_121", 1));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_TRAP_2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_ORION", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("ROKAS28_TRAP_dlg2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

