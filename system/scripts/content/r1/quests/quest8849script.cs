//--- Melia Script -----------------------------------------------------------
// Magical Opinion (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Edita.
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

[QuestScript(8849)]
public class Quest8849Script : QuestScript
{
	protected override void Load()
	{
		SetId(8849);
		SetName("Magical Opinion (1)");
		SetDescription("Talk to Bokor Edita");

		AddPrerequisite(new LevelPrerequisite(196));

		AddObjective("collect0", "Collect 8 Dark Crystal(s)", new CollectItemObjective("FLASH64_SQ_05_ITEM", 8));
		AddDrop("FLASH64_SQ_05_ITEM", 7.5f, 41299, 47307, 47464);

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_EDITA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_EDITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_SQ_05_01", "FLASH64_SQ_05", "I'll help", "About the curse of the Petrifying Frost", "I'm busy"))
		{
			case 1:
				await dialog.Msg("FLASH64_SQ_05_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH64_SQ_05_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FLASH64_SQ_05_ITEM", 8))
		{
			character.Inventory.RemoveItem("FLASH64_SQ_05_ITEM", 8);
			await dialog.Msg("FLASH64_SQ_05_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

