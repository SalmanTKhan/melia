//--- Melia Script -----------------------------------------------------------
// In an Unexpected Place
//--- Description -----------------------------------------------------------
// Quest to Talk to Merrisa.
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

[QuestScript(50282)]
public class Quest50282Script : QuestScript
{
	protected override void Load()
	{
		SetId(50282);
		SetName("In an Unexpected Place");
		SetDescription("Talk to Merrisa");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new ItemPrerequisite("PILGRIM48_HIDDENQ1_ITEM1", 1));

		AddReward(new ItemReward("Gacha_H_002", 1));

		AddDialogHook("PILGRIM_48_JURATE", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_JURATE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM48_HQ1_start1", "PILGRIM48_HQ1", "I'll try to find them", "You should go find it yourself."))
		{
			case 1:
				await dialog.Msg("PILGRIM48_HQ1_agree1");
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

		if (character.Inventory.HasItem("PILGRIM48_HIDDENQ1_ITEM2", 4))
		{
			character.Inventory.RemoveItem("PILGRIM48_HIDDENQ1_ITEM2", 4);
			await dialog.Msg("PILGRIM48_HQ1_succ1");
			// Func/PILGRIM48_HIDDENQ1_COMP;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

