//--- Melia Script -----------------------------------------------------------
// Time Stops Along With the Season (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Ida.
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

[QuestScript(90115)]
public class Quest90115Script : QuestScript
{
	protected override void Load()
	{
		SetId(90115);
		SetName("Time Stops Along With the Season (2)");
		SetDescription("Talk to Chronomancer Ida");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_1_SQ_70"));

		AddDialogHook("MAPLE_25_1_AIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_AIDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_1_SQ_80_ST", "MAPLE_25_1_SQ_80", "What should I check and how?", "It looks quite dangerous."))
		{
			case 1:
				await dialog.Msg("MAPLE_25_1_SQ_80_AG");
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

		if (character.Inventory.HasItem("MAPLE_25_1_SQ_80_ITEM", 1))
		{
			character.Inventory.RemoveItem("MAPLE_25_1_SQ_80_ITEM", 1);
			await dialog.Msg("MAPLE_25_1_SQ_80_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

