//--- Melia Script -----------------------------------------------------------
// Secure Supply Route
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91105)]
public class Quest91105Script : QuestScript
{
	protected override void Load()
	{
		SetId(91105);
		SetName("Secure Supply Route");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE3_MQ_5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(464));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_4"));

		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_3_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE3_MQ_5_SNPC_DLG1", "EP14_1_FCASTLE3_MQ_5", "Say that you think it's a good idea", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE3_MQ_5_SNPC_DLG2");
				dialog.UnHideNPC("EP14_1_FCASTLE3_MQ_5_HIDDEN");
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

		await dialog.Msg("EP14_1_FCASTLE3_MQ_5_CNPC_DLG1");
		dialog.HideNPC("EP14_1_FCASTLE3_MQ_5_HIDDEN");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

