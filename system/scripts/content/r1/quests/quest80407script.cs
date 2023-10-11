//--- Melia Script -----------------------------------------------------------
// Techniques of an Outlaw
//--- Description -----------------------------------------------------------
// Quest to Talk to Outlaw Master Maea Kellefinker.
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

[QuestScript(80407)]
public class Quest80407Script : QuestScript
{
	protected override void Load()
	{
		SetId(80407);
		SetName("Techniques of an Outlaw");
		SetDescription("Talk to Outlaw Master Maea Kellefinker");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_OUTLAW_Q1_TRACK_RE", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("OUTLAW_MASTER_W_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("OUTLAW_MASTER_W_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_OUTLAW_Q1_1", "JOB_OUTLAW_Q1", "I accept.", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_OUTLAW_Q1_2");
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

