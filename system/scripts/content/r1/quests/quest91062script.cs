//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (7)
//--- Description -----------------------------------------------------------
// Quest to Check the Broken Cabinet.
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

[QuestScript(91062)]
public class Quest91062Script : QuestScript
{
	protected override void Load()
	{
		SetId(91062);
		SetName("Secrets Hidden Underground (7)");
		SetDescription("Check the Broken Cabinet");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON2_MQ_7_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_6"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_STORAGEBOX", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_SAFEZONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_2_DPRISON2_MQ_7_DLG1", "EP13_2_DPRISON2_MQ_7", "Let's check", "Please wait a moment"))
		{
			case 1:
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_1");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_2");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_3");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_4");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_5");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_6");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_7");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_NPC_SOULFRAGMENT_8");
				dialog.HideNPC("EP13_2_DPRISON2_MQ_STORAGEBOX");
				dialog.UnHideNPC("EP13_2_DPRISON2_MQ_SAFEZONE");
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

		await dialog.Msg("BalloonText/EP13_2_DPRISON2_MQ_7_DLG2/5");
		dialog.HideNPC("EP13_2_DPRISON2_MQ_SAFEZONE");
		// Func/SCR_EP13_2_DPRISON2_MQ_7_ENDSCRIPT;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

