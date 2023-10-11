//--- Melia Script -----------------------------------------------------------
// Plot Twist (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90104)]
public class Quest90104Script : QuestScript
{
	protected override void Load()
	{
		SetId(90104);
		SetName("Plot Twist (1)");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_90"));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_100_ST", "MAPLE_25_3_SQ_100", "But what Aeglei said makes sense too.", "I think Lina is right."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_100_AG");
				dialog.HideNPC("MAPLE_25_3_EGLE");
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

		await dialog.Msg("MAPLE_25_3_SQ_100_SU1");
		await dialog.Msg("MAPLE_25_3_SQ_100_SU2");
		await Task.Delay(1000);
		// Func/MAPLE_25_3_SQ_100_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

