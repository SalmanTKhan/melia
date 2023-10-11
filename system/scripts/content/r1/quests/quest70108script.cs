//--- Melia Script -----------------------------------------------------------
// Looking Back Sometimes
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Wiley.
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

[QuestScript(70108)]
public class Quest70108Script : QuestScript
{
	protected override void Load()
	{
		SetId(70108);
		SetName("Looking Back Sometimes");
		SetDescription("Talk to Monk Wiley");

		AddPrerequisite(new LevelPrerequisite(173));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_SQ_03_1", "THORN39_2_SQ03", "Tell him that you will help", "Reject since you are busy"))
		{
			case 1:
				await dialog.Msg("THORN39_2_SQ_03_2");
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

		if (character.Inventory.HasItem("THORN39_2_SQ03_ITEM", 8))
		{
			character.Inventory.RemoveItem("THORN39_2_SQ03_ITEM", 8);
			await dialog.Msg("THORN39_2_SQ_03_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

