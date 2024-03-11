//--- Melia Script -----------------------------------------------------------
// How To Use The Flute
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pied Piper Master.
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

[QuestScript(80402)]
public class Quest80402Script : QuestScript
{
	protected override void Load()
	{
		SetId(80402);
		SetName("How To Use The Flute");
		SetDescription("Talk to the Pied Piper Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PIED_PIPER_Q1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("PIED_PIPER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("PIED_PIPER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PIED_PIPER_Q1_ST1", "JOB_PIED_PIPER_Q1", "Yes, I need it.", "No, I don't need it."))
		{
			case 1:
				await dialog.Msg("JOB_PIED_PIPER_Q1_AFST");
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

		await dialog.Msg("JOB_PIED_PIPER_Q1_SU1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

