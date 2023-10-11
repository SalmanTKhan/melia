//--- Melia Script -----------------------------------------------------------
// Secret of the Destroyed Altar
//--- Description -----------------------------------------------------------
// Quest to Northern Rudiziu Trail Altar.
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

[QuestScript(19700)]
public class Quest19700Script : QuestScript
{
	protected override void Load()
	{
		SetId(19700);
		SetName("Secret of the Destroyed Altar");
		SetDescription("Northern Rudiziu Trail Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM50_SQ_090_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("kill0", "Kill 1 Merge", new KillObjective(1, MonsterId.Boss_Merge_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("PILGRIM50_SQ_090_ITEM", 1));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ALTAR01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_GHOST4", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PILGRIM50_SQ_090_COMP");
		ZoneServer.Instance.World.FindNPC("PILGRIM50_GHOST4")?.PlayEffectLocal(character.Connection, "I_smoke013_dark", 1f, "BOT");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("PILGRIM50_GHOST4");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "The Pilgrim's Soul disappeared!", 3);
		await Task.Delay(4000);
		// Func/SCR_PILGRIM50_PC_ASIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

