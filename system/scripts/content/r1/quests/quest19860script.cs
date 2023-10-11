//--- Melia Script -----------------------------------------------------------
// With Devotion
//--- Description -----------------------------------------------------------
// Quest to Receive the Sanctum's Blessing.
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

[QuestScript(19860)]
public class Quest19860Script : QuestScript
{
	protected override void Load()
	{
		SetId(19860);
		SetName("With Devotion");
		SetDescription("Receive the Sanctum's Blessing");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM51_SQ_10_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(129));

		AddObjective("kill0", "Kill 1 Ironbaum", new KillObjective(1, MonsterId.Boss_Ironbaum_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("NECK01_135", 1));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_SR07", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR07", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've defeated Ironbaum that was going after the pilgrim! Now, you will receive the blessing from the sanctum.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

