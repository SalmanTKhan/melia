//--- Melia Script -----------------------------------------------------------
// Headstone on Neryskus Grounds Pathway
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

[QuestScript(91028)]
public class Quest91028Script : QuestScript
{
	protected override void Load()
	{
		SetId(91028);
		SetName("Headstone on Neryskus Grounds Pathway");
		SetDescription("Talk to Rangda Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ04_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03_1"), new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03_2"), new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03_3"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ04_STONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ04_DLG_01", "EP12_2_F_CASTLE_101_MQ04", "What is it? ", "I don't want to worry about it at the moment"))
		{
			case 1:
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_02");
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_03");
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_04");
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_DLG_05");
				await dialog.Msg("BalloonText/EP12_2_F_CASTLE_101_MQ04_DLG_20/3");
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


		return HookResult.Break;
	}
}

