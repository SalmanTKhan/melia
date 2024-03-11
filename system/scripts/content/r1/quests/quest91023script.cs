//--- Melia Script -----------------------------------------------------------
// Save the Randa Girl.
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

[QuestScript(91023)]
public class Quest91023Script : QuestScript
{
	protected override void Load()
	{
		SetId(91023);
		SetName("Save the Randa Girl.");
		SetDescription("Talk to Rangda Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ02_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ_MASTER_01", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ_GIRL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ02_DLG_01", "EP12_2_F_CASTLE_101_MQ02", "I want to help to save the child", "Ask the identity", "I want to take a look around here more"))
		{
			case 1:
				dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_MASTER_01");
				// Func/SCR_RANGDAMASTER_SUMMON;
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER01");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER02");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER03");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER04");
				dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ02_BOWER05");
				await dialog.Msg("BalloonText/EP12_2_F_CASTLE_101_MQ02_DLG_03/5");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ01_DLG_5");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP12_2_F_CASTLE_101_MQ02_DLG_02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_F_CASTLE_101_MQ03");
	}
}

