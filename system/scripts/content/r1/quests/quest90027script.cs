//--- Melia Script -----------------------------------------------------------
// Lure it deeper
//--- Description -----------------------------------------------------------
// Quest to Talk to Mayor Frege.
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

[QuestScript(90027)]
public class Quest90027Script : QuestScript
{
	protected override void Load()
	{
		SetId(90027);
		SetName("Lure it deeper");
		SetDescription("Talk to Mayor Frege");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CORAL_32_1_SQ_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_6"));

		AddObjective("kill0", "Kill 27 Blue Terra Imp(s) or Greentoshell(s)", new KillObjective(27, 57950, 41316));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_PEOPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_PEOPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_8_ST", "CORAL_32_1_SQ_8", "Sure, I'll help", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_8_AG");
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

		await dialog.Msg("CORAL_32_1_SQ_8_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

