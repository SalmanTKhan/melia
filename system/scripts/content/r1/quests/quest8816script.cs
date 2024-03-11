//--- Melia Script -----------------------------------------------------------
// A Chance of Recovery (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Cryomancer Kostas.
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

[QuestScript(8816)]
public class Quest8816Script : QuestScript
{
	protected override void Load()
	{
		SetId(8816);
		SetName("A Chance of Recovery (1)");
		SetDescription("Talk to Cryomancer Kostas");

		AddPrerequisite(new LevelPrerequisite(187));

		AddObjective("collect0", "Collect 12 Reaction Stone(s)", new CollectItemObjective("FLASH60_SQ_04_ITEM", 12));
		AddDrop("FLASH60_SQ_04_ITEM", 7f, 47471, 47469);

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_KOSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_KOSTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_04_01", "FLASH60_SQ_04", "Tell him that you would help", "About the symbol of Schilt", "Decline"))
		{
			case 1:
				await dialog.Msg("FLASH60_SQ_04_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH60_SQ_04_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FLASH60_SQ_04_ITEM", 12))
		{
			character.Inventory.RemoveItem("FLASH60_SQ_04_ITEM", 12);
			await dialog.Msg("FLASH60_SQ_04_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

