//--- Melia Script -----------------------------------------------------------
// First Aid(1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Narius.
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

[QuestScript(90193)]
public class Quest90193Script : QuestScript
{
	protected override void Load()
	{
		SetId(90193);
		SetName("First Aid(1)");
		SetDescription("Speak with Loremaster Narius");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_50"));

		AddObjective("collect0", "Collect 15 Coral powder of Nimrah Damsel(s)", new CollectItemObjective("CORAL_44_1_SQ_60_ITEM", 15));
		AddDrop("CORAL_44_1_SQ_60_ITEM", 10f, "NimrahDamsel");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_1_MAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_OLDMAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_60_ST", "CORAL_44_1_SQ_60", "Of course I will help.", "My hands are tied at the moment."))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_60_AG");
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

		if (character.Inventory.HasItem("CORAL_44_1_SQ_60_ITEM", 15))
		{
			character.Inventory.RemoveItem("CORAL_44_1_SQ_60_ITEM", 15);
			await dialog.Msg("CORAL_44_1_SQ_60_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

