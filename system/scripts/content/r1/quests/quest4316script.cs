//--- Melia Script -----------------------------------------------------------
// Historian's Trick
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Viode.
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

[QuestScript(4316)]
public class Quest4316Script : QuestScript
{
	protected override void Load()
	{
		SetId(4316);
		SetName("Historian's Trick");
		SetDescription("Talk to Historian Viode");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS24_KILL2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("kill0", "Kill 7 Dandel(s) or Pino(s) or Geppetto(s)", new KillObjective(7, 401401, 401181, 401101));

		AddDialogHook("ROKAS_24_BEARD", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_BEARD_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_KILL2_start", "ROKAS24_KILL2", "Thank you for the advice, but I'll be alright", "Look around"))
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

		await dialog.Msg("ROKAS24_KILL2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

