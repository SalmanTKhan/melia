//--- Melia Script -----------------------------------------------------------
// Old Pride
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zydrone.
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

[QuestScript(60006)]
public class Quest60006Script : QuestScript
{
	protected override void Load()
	{
		SetId(60006);
		SetName("Old Pride");
		SetDescription("Talk to Kupole Zydrone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON511_MQ_05_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_04"));

		AddObjective("kill0", "Kill 1 Demon Lord Blut", new KillObjective(1, MonsterId.Boss_Blud));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));
		AddReward(new ItemReward("Vis", 35032));

		AddDialogHook("VPRISON511_MQ_ZYDRONE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON511_MQ_ZYDRONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_05_01", "VPRISON511_MQ_05", "All prepared", "I'm not ready yet"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("VPRISON511_MQ_05_03");
		dialog.HideNPC("VPRISON511_MQ_ZYDRONE");
		await dialog.Msg("FadeOutIN/1500");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Meet Kupole Arune by moving to the 2nd area of Demons Prison!");
		// Func/VPRISON511_MQ_05_HAUBERK_01;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

