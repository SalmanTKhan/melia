//--- Melia Script -----------------------------------------------------------
// Sea Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80107)]
public class Quest80107Script : QuestScript
{
	protected override void Load()
	{
		SetId(80107);
		SetName("Sea Magic Circle");
		SetDescription("Talk to Kabbalist Lutas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_35_2_SQ_9_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_8"));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_35_2_SQ_9_start", "CORAL_35_2_SQ_9", "I'll go there.", "That's going to be difficult."))
		{
			case 1:
				// Func/CORAL_35_2_HIDE_FUNC;
				dialog.HideNPC("CORAL_35_2_LUTAS_2");
				dialog.UnHideNPC("CORAL_35_2_LUTAS_3");
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

		await dialog.Msg("CORAL_35_2_SQ_9_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

