//--- Melia Script -----------------------------------------------------------
// Record of Ancient
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rangda Girl.
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

[QuestScript(91024)]
public class Quest91024Script : QuestScript
{
	protected override void Load()
	{
		SetId(91024);
		SetName("Record of Ancient");
		SetDescription("Talk to the Rangda Girl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ03_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ02"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ_GIRL_01", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ_MASTER_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ03_DLG_01", "EP12_2_F_CASTLE_101_MQ03", "Feel safe, I'll look around.", "There are no times to stay here."))
		{
			case 1:
				await dialog.Msg("BalloonText/EP12_2_F_CASTLE_101_MQ03_DLG_15/3");
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

		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_01");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_MASTER_02");
		await dialog.Msg("FadeOutIN/3");
		// Func/SCR_RANGDA_SUMMON_EP12_2_F_CASTLE_101_MQ03;
		await dialog.Msg("EP12_2_F_CASTLE_101_MQ03_DLG_14");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER01");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER02");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER03");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER04");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER05");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

