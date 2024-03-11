//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (4)
//--- Description -----------------------------------------------------------
// Quest to Move to the marked area on Stonemason Pipoti's map.
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

[QuestScript(1057)]
public class Quest1057Script : QuestScript
{
	protected override void Load()
	{
		SetId(1057);
		SetName("Treasure Map of the Stonemason's Family (4)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_PIPOTI05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI04"));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(1, MonsterId.Boss_Werewolf_Q2));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI05_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI05_TREASUREBOX", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_ROKAS30_PIPOTI05_TREASUREBOX_OPEN;
		await Task.Delay(1000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've failed to find the treasure of the Stonemason family!{nl}Pipoti disappeared, but you will have a chance to meet him again!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

