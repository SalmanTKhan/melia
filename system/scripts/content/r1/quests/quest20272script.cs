//--- Melia Script -----------------------------------------------------------
// Root of Tankinta Vacant Lot
//--- Description -----------------------------------------------------------
// Quest to Check Tankinta Vacant Lot.
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

[QuestScript(20272)]
public class Quest20272Script : QuestScript
{
	protected override void Load()
	{
		SetId(20272);
		SetName("Root of Tankinta Vacant Lot");
		SetDescription("Check Tankinta Vacant Lot");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN21_MQ05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ09"));

		AddObjective("kill0", "Kill 1 Molich", new KillObjective(1, MonsterId.Boss_Molich));
		AddObjective("kill1", "Kill 1 Bramble's Root", new KillObjective(1, MonsterId.Npc_Bramble_Root));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BRAMBLE02_ROOT", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER04", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("THORN21_MQ05_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

