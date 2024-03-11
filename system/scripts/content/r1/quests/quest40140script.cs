//--- Melia Script -----------------------------------------------------------
// Needing the Nutritious Tonic (3)
//--- Description -----------------------------------------------------------
// Quest to Give tonic to Dalius.
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

[QuestScript(40140)]
public class Quest40140Script : QuestScript
{
	protected override void Load()
	{
		SetId(40140);
		SetName("Needing the Nutritious Tonic (3)");
		SetDescription("Give tonic to Dalius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_4_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_070"));

		AddDialogHook("FARM47_DALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_STEPAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_080_ST", "FARM47_4_SQ_080", "Take this medicine", "You don't feel like offering him that much"))
		{
			case 1:
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

		await dialog.Msg("FARM47_4_SQ_080_COMP");
		await Task.Delay(2000);
		// Func/SCR_FARM47_4_SQ_080_COMP_MSG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

