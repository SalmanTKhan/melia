//--- Melia Script -----------------------------------------------------------
// Crazy Archivist (2)
//--- Description -----------------------------------------------------------
// Quest to Find Archivist Jonas.
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

[QuestScript(4432)]
public class Quest4432Script : QuestScript
{
	protected override void Load()
	{
		SetId(4432);
		SetName("Crazy Archivist (2)");
		SetDescription("Find Archivist Jonas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS24_QB_5_NEW_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_DIALOG1"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_FLORIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_FLORIJONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_5_select1", "ROKAS24_QB_5", "Persuade him to go back since this place is too dangerous", "Alright"))
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

		await dialog.Msg("ROKAS24_QB_5_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

