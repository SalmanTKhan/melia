//--- Melia Script -----------------------------------------------------------
// Ritual for the Sea(1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90195)]
public class Quest90195Script : QuestScript
{
	protected override void Load()
	{
		SetId(90195);
		SetName("Ritual for the Sea(1)");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_70"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_80_ST", "CORAL_44_1_SQ_80", "What should I do?", "I will think about it"))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_80_AG");
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

		if (character.Inventory.HasItem("CORAL_44_1_SQ_80_ITEM", 9))
		{
			character.Inventory.RemoveItem("CORAL_44_1_SQ_80_ITEM", 9);
			await dialog.Msg("CORAL_44_1_SQ_80_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

