//--- Melia Script -----------------------------------------------------------
// For Death (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Demon Svitrigaila.
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

[QuestScript(40890)]
public class Quest40890Script : QuestScript
{
	protected override void Load()
	{
		SetId(40890);
		SetName("For Death (1)");
		SetDescription("Talk with Demon Svitrigaila");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_58_SQ_040_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_030"));

		AddObjective("collect0", "Collect 1 Barrier Stone Core", new CollectItemObjective("FLASH_58_SQ_040_ITEM_1", 1));
		AddDrop("FLASH_58_SQ_040_ITEM_1", 10f, "soul_gathering_mchn_2");

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_040_ST", "FLASH_58_SQ_040", "I will destroy the integrator", "About the integrator", "I will stop helping"))
		{
			case 1:
				await dialog.Msg("FLASH_58_SQ_040_AC");
				await Task.Delay(1000);
				// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("FLASH_58_SQ_040_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FLASH_58_SQ_040_ITEM_1", 1))
		{
			character.Inventory.RemoveItem("FLASH_58_SQ_040_ITEM_1", 1);
			await dialog.Msg("FLASH_58_SQ_040_COMP");
			// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD_OFF;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

