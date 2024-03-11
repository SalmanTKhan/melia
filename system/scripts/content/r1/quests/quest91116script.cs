//--- Melia Script -----------------------------------------------------------
// Reality of Ominous Sign
//--- Description -----------------------------------------------------------
// Quest to Move to the Crow's Nest.
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

[QuestScript(91116)]
public class Quest91116Script : QuestScript
{
	protected override void Load()
	{
		SetId(91116);
		SetName("Reality of Ominous Sign");
		SetDescription("Move to the Crow's Nest");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP14_1_FCASTLE4_MQ_8_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_7"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29358));

		AddDialogHook("EP14_1_FCASTLE4_MQ_8_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE4_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("EP14_1_FCASTLE4_MQ_8_SNPCD_CNPC_DLG1");
		dialog.HideNPC("EP14_1_FCASTLE4_MQ_8_HIDDEN");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("EP14_1_FCASTLE4_MQ_8_NPC1");
		dialog.HideNPC("EP14_1_FCASTLE4_MQ_8_NPC2");
		dialog.UnHideNPC("EP14_1_FCASTLE5_MQ_1_NPC1");
		dialog.UnHideNPC("EP14_1_FCASTLE5_MQ_1_NPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

