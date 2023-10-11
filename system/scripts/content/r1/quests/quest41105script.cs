//--- Melia Script -----------------------------------------------------------
// Deploying Investigation Guards
//--- Description -----------------------------------------------------------
// Quest to Talk to Gedas.
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

[QuestScript(41105)]
public class Quest41105Script : QuestScript
{
	protected override void Load()
	{
		SetId(41105);
		SetName("Deploying Investigation Guards");
		SetDescription("Talk to Gedas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_36_2_SQ_105_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_100"));

		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_105_ST", "PILGRIM_36_2_SQ_105", "Alright", "I better get going."))
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

		await dialog.Msg("PILGRIM_36_2_SQ_105_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

