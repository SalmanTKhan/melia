//--- Melia Script -----------------------------------------------------------
// A Place Unreachable (3)
//--- Description -----------------------------------------------------------
// Quest to Enter the 1st District of the Demon's Prison.
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

[QuestScript(60002)]
public class Quest60002Script : QuestScript
{
	protected override void Load()
	{
		SetId(60002);
		SetName("A Place Unreachable (3)");
		SetDescription("Enter the 1st District of the Demon's Prison");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON511_MQ_01_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_PRE_02"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));

		AddDialogHook("VPRISON511_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_HAUBERK", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("VPRISON511_MQ_01_03");
		// Func/VPRISON511_MQ_01_03_SCR_01;
		// Func/TO_VELNIASP511_PORTAL_PC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

