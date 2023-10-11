//--- Melia Script -----------------------------------------------------------
// Ritual for the Sea(2)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90196)]
public class Quest90196Script : QuestScript
{
	protected override void Load()
	{
		SetId(90196);
		SetName("Ritual for the Sea(2)");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CORAL_44_1_SQ_90_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_80"));

		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_90_ST", "CORAL_44_1_SQ_90", "Tell him that it won't be a problem", "Just wait a moment."))
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


		return HookResult.Break;
	}
}

