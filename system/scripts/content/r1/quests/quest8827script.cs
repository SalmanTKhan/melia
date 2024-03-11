//--- Melia Script -----------------------------------------------------------
// Passing Time
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Nomabis.
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

[QuestScript(8827)]
public class Quest8827Script : QuestScript
{
	protected override void Load()
	{
		SetId(8827);
		SetName("Passing Time");
		SetDescription("Talk to Guard Nomabis");

		AddPrerequisite(new LevelPrerequisite(190));

		AddObjective("collect0", "Collect 10 Damaged Artifacts(s)", new CollectItemObjective("FLASH61_SQ_06_ITEM", 10));
		AddDrop("FLASH61_SQ_06_ITEM", 5f, 57635, 47470, 47478);

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_NOBAVIS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_NOBAVIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_06_01", "FLASH61_SQ_06", "Tell him that you would bring it fast", "About Sabina", "Everything will be alright"))
		{
			case 1:
				await dialog.Msg("FLASH61_SQ_06_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH61_SQ_06_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FLASH61_SQ_06_ITEM", 10))
		{
			character.Inventory.RemoveItem("FLASH61_SQ_06_ITEM", 10);
			await dialog.Msg("FLASH61_SQ_06_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

