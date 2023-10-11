//--- Melia Script -----------------------------------------------------------
// Arbitration Initiation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aeglei.
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

[QuestScript(90101)]
public class Quest90101Script : QuestScript
{
	protected override void Load()
	{
		SetId(90101);
		SetName("Arbitration Initiation (1)");
		SetDescription("Talk to Kupole Aeglei");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_60"));

		AddObjective("kill0", "Kill 24 Nuttabug(s) or Nuttafly(s) or Rodejokel(s)", new KillObjective(24, 58537, 58544, 58536));

		AddReward(new ExpReward(7261044, 7261044));
		AddReward(new ItemReward("expCard13", 5));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_EGLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_70_ST", "MAPLE_25_3_SQ_70", "I sincerely want to help.", "Alright"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_70_AG");
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

		await dialog.Msg("MAPLE_25_3_SQ_70_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

