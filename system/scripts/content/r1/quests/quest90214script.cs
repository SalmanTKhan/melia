//--- Melia Script -----------------------------------------------------------
// Destroy the Demon Device(3)
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

[QuestScript(90214)]
public class Quest90214Script : QuestScript
{
	protected override void Load()
	{
		SetId(90214);
		SetName("Destroy the Demon Device(3)");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_44_3_SQ_40_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_30"));

		AddObjective("kill0", "Kill 8 Varle Anchor(s) or Varle Henchmen(s) or Varle Skipper(s) or Varle Helmsman(s) or Nimrah Frieker(s)", new KillObjective(8, 58830, 58829, 58828, 58831, 58880));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_3_OLDMAN3", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_40_ST", "CORAL_44_3_SQ_40", "I'll go there", "I'll wait here"))
		{
			case 1:
				await dialog.Msg("CORAL_44_3_SQ_40_AG");
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

		await dialog.Msg("CORAL_44_3_SQ_40_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

