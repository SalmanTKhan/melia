//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50348)]
public class Quest50348Script : QuestScript
{
	protected override void Load()
	{
		SetId(50348);
		SetName("In to the Lion's Mouth (5)");
		SetDescription("Talk to Monk Aistis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY22_4_SQ5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ4"));

		AddDialogHook("ABBEY22_4_SUBQ5_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ5_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ5_START1", "ABBEY22_4_SQ5", "Who are you talking about?", "Get out of the area."))
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

		await dialog.Msg("ABBEY22_4_SUBQ5_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

