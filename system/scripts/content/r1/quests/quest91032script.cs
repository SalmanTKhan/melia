//--- Melia Script -----------------------------------------------------------
// The Way Back Home
//--- Description -----------------------------------------------------------
// Quest to Talk to Rangda Master.
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

[QuestScript(91032)]
public class Quest91032Script : QuestScript
{
	protected override void Load()
	{
		SetId(91032);
		SetName("The Way Back Home");
		SetDescription("Talk to Rangda Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ06_TRACK_01", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ05"));

		AddObjective("kill0", "Kill 1 Bower Keeper", new KillObjective(1, MonsterId.Boss_BowerKeeper));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ_MASTER_03", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ_MASTER_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ06_DLG_1", "EP12_2_F_CASTLE_101_MQ06", "I have a place that comes to my mind", "I'm still confused"))
		{
			case 1:
				// Func/SCR_EP12_2_F_CASTLE_101_MQ06_BEFORE_TRACK;
				dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_MASTER_03");
				dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_03");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_04");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ_MASTER_04");
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

		await dialog.Msg("EP12_2_F_CASTLE_101_MQ06_DLG_4");
		await dialog.Msg("FadeOutIN/3");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_04");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_MASTER_04");
		dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ01_MASTER");
		dialog.UnHideNPC("EP12_2_D_DCAPITAL_108_MQ02_GIRL");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

