//--- Melia Script -----------------------------------------------------------
// Headstone at Spraga Grounds
//--- Description -----------------------------------------------------------
// Quest to Find the Ancient Headstone and decipher it.
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

[QuestScript(91031)]
public class Quest91031Script : QuestScript
{
	protected override void Load()
	{
		SetId(91031);
		SetName("Headstone at Spraga Grounds");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ05_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ04_1"), new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ04_2"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("EP12_2_F_CASTLE_101_MQ05_ITEM_01", 1));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ_GIRL_02", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_EP12_2_F_CASTLE_101_MQ05_ENDING_TRACK;
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_02");
		dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ_GIRL_03");
		dialog.HideNPC("EP12_2_F_CASTLE_101_MQ05_TRACK");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

