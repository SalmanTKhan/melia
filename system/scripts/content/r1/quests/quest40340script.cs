//--- Melia Script -----------------------------------------------------------
// Positive Evidence (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Varas.
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

[QuestScript(40340)]
public class Quest40340Script : QuestScript
{
	protected override void Load()
	{
		SetId(40340);
		SetName("Positive Evidence (1)");
		SetDescription("Talk to Varas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_2_SQ_070_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(89));
		AddPrerequisite(new CompletedPrerequisite("FARM47_2_SQ_060"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_JONARIS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JONARIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_2_SQ_070_ST", "FARM47_2_SQ_070", "I will eliminate the magic circle for him", "About the magic circles", "Tell him to leave it since it may be the purification magic circle"))
		{
			case 1:
				await dialog.Msg("FARM47_2_SQ_070_AC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("FARM47_2_SQ_070_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_2_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

