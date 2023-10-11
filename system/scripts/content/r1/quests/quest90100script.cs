//--- Melia Script -----------------------------------------------------------
// Naturally (2)
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

[QuestScript(90100)]
public class Quest90100Script : QuestScript
{
	protected override void Load()
	{
		SetId(90100);
		SetName("Naturally (2)");
		SetDescription("Talk to Kupole Aeglei");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_50"));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_60_ST", "MAPLE_25_3_SQ_60", "Wait, what? Uhm... yeah, I guess?", "I don't know who you are but Lina is right."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_60_AG");
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

		await dialog.Msg("MAPLE_25_3_SQ_60_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

