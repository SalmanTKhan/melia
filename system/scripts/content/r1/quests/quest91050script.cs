//--- Melia Script -----------------------------------------------------------
// Ragana's Suggestion
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91050)]
public class Quest91050Script : QuestScript
{
	protected override void Load()
	{
		SetId(91050);
		SetName("Ragana's Suggestion");
		SetDescription("Talk to the Goddess Lada");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_3_MQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_03"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_3_MQ_BAIGA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_04_DLG1", "EP13_F_SIAULIAI_3_MQ_04", "I'll go investigate on the Rohonsa Cliff", "I need to take a break"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_LADA_2");
				dialog.UnHideNPC("EP13_F_SIAULIAI_3_MQ_04_TRACK_1");
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

		await dialog.Msg("EP13_F_SIAULIAI_3_MQ_04_DLG2");
		dialog.HideNPC("EP13_F_SIAULIAI_3_MQ_04_TRACK_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

