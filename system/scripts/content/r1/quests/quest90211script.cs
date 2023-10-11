//--- Melia Script -----------------------------------------------------------
// Figuring out the situation
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

[QuestScript(90211)]
public class Quest90211Script : QuestScript
{
	protected override void Load()
	{
		SetId(90211);
		SetName("Figuring out the situation");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_44_3_SQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_80"));

		AddObjective("kill0", "Kill 4 Varle Anchor(s)", new KillObjective(4, MonsterId.VarleAnchor));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_3_OLDMAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_OLDMAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_10_ST", "CORAL_44_3_SQ_10", "I'll go there", "Let me get ready"))
		{
			case 1:
				await dialog.Msg("CORAL_44_3_SQ_10_AG");
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

		await dialog.Msg("CORAL_44_3_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

