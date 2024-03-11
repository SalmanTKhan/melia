//--- Melia Script -----------------------------------------------------------
// Small Difference (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Grave Robber Stephonas.
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

[QuestScript(8837)]
public class Quest8837Script : QuestScript
{
	protected override void Load()
	{
		SetId(8837);
		SetName("Small Difference (1)");
		SetDescription("Talk with Grave Robber Stephonas");

		AddPrerequisite(new LevelPrerequisite(193));
		AddPrerequisite(new CompletedPrerequisite("FLASH63_SQ_03"));

		AddObjective("collect0", "Collect 7 Hardened Explosives(s)", new CollectItemObjective("FLASH63_SQ_05_ITEM", 7));
		AddDrop("FLASH63_SQ_05_ITEM", 10f, 47306, 57636, 57634);

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_STEPONAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_STEPONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_05_01", "FLASH63_SQ_05", "Ask him how you can help", "Tell him that you will leave since it seems dangerous"))
		{
			case 1:
				await dialog.Msg("FLASH63_SQ_05_01_01");
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

		if (character.Inventory.HasItem("FLASH63_SQ_05_ITEM", 7))
		{
			character.Inventory.RemoveItem("FLASH63_SQ_05_ITEM", 7);
			await dialog.Msg("FLASH63_SQ_05_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

