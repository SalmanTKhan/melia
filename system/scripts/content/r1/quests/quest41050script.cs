//--- Melia Script -----------------------------------------------------------
// Beginning of Doubt
//--- Description -----------------------------------------------------------
// Quest to Talk to Damijonas.
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

[QuestScript(41050)]
public class Quest41050Script : QuestScript
{
	protected override void Load()
	{
		SetId(41050);
		SetName("Beginning of Doubt");
		SetDescription("Talk to Damijonas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_040"));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_SQ_050_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_050_ST", "PILGRIM_36_2_SQ_050", "Explain why you have destroyed them", "Run away"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_050_AC");
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

		await Task.Delay(1000);
		// Func/PILGRIM_36_2_SQ_050_COMP_BM;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

