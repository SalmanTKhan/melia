//--- Melia Script -----------------------------------------------------------
// Origins of the Curse
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Daram.
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

[QuestScript(50285)]
public class Quest50285Script : QuestScript
{
	protected override void Load()
	{
		SetId(50285);
		SetName("Origins of the Curse");
		SetDescription("Talk to Priest Daram");

		AddPrerequisite(new LevelPrerequisite(140));

		AddObjective("collect0", "Collect 6 Dawn Maiden Essence(s)", new CollectItemObjective("CHATHEDRAL54_HIDDENQ1_ITEM1", 6));
		AddDrop("CHATHEDRAL54_HIDDENQ1_ITEM1", 10f, "NightMaiden_mage");

		AddReward(new ItemReward("Gacha_H_003", 1));

		AddDialogHook("CHATHEDRAL54_SQ01_PART1", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_SQ01_PART1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_HQ1_start1", "CHATHEDRAL54_HQ1", "I can get the Dawn Maiden essence.", "I feel like resting for a while now."))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL54_HQ1_agree1");
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

		if (character.Inventory.HasItem("CHATHEDRAL54_HIDDENQ1_ITEM1", 6))
		{
			character.Inventory.RemoveItem("CHATHEDRAL54_HIDDENQ1_ITEM1", 6);
			await dialog.Msg("CHATHEDRAL54_HQ1_succ1");
			// Func/CHATHEDRAL54_HIDDENQ1_COMP;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

