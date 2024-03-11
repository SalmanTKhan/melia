//--- Melia Script -----------------------------------------------------------
// Result and Responsibility
//--- Description -----------------------------------------------------------
// Quest to Return to Damijonas.
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

[QuestScript(41055)]
public class Quest41055Script : QuestScript
{
	protected override void Load()
	{
		SetId(41055);
		SetName("Result and Responsibility");
		SetDescription("Return to Damijonas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_050"));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_055_ST", "PILGRIM_36_2_SQ_055", "Apologize and seek for forgiveness", "Let's run away"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_055_AC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM_36_2_SQ_055_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

