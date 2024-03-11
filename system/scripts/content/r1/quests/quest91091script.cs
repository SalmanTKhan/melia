//--- Melia Script -----------------------------------------------------------
// To the Delmore Manor
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(91091)]
public class Quest91091Script : QuestScript
{
	protected override void Load()
	{
		SetId(91091);
		SetName("To the Delmore Manor");
		SetDescription("Talk to the Centurion Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE1_MQ_7_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE1_MQ_6"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP14_1_F_CASTLE_1_FOLLOW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_1_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE1_MQ_7_SNPC_DLG1", "EP14_1_FCASTLE1_MQ_7", "I'll join", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE1_MQ_7_SNPC_DLG2");
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

		await dialog.Msg("EP14_1_FCASTLE1_MQ_7_CNPC_DLG1");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

