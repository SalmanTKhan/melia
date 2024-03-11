//--- Melia Script -----------------------------------------------------------
// Magic Barrier Blocking the Way
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91155)]
public class Quest91155Script : QuestScript
{
	protected override void Load()
	{
		SetId(91155);
		SetName("Magic Barrier Blocking the Way");
		SetDescription("Talk to the General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE3_MQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(478));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_11"));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_DCASTLE3_RAMIN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_DCASTLE3_RAMIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE3_MQ_1_DLG1", "EP14_2_DCASTLE3_MQ_1", "Alright", "I still have other things to do"))
		{
			case 1:
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("EP14_2_DCASTLE3_MQ_1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

