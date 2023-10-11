//--- Melia Script -----------------------------------------------------------
// A wild prescription
//--- Description -----------------------------------------------------------
// Quest to Talk to Outsider Mark.
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

[QuestScript(70500)]
public class Quest70500Script : QuestScript
{
	protected override void Load()
	{
		SetId(70500);
		SetName("A wild prescription");
		SetDescription("Talk to Outsider Mark");

		AddPrerequisite(new LevelPrerequisite(258));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_01_start", "PILGRIM41_1_SQ01", "Say that you will gather the Shining Horns from the Tinis", "Say that you have something better to do"))
		{
			case 1:
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

		if (character.Inventory.HasItem("PILGRIM41_1_SQ01_ITEM", 13))
		{
			character.Inventory.RemoveItem("PILGRIM41_1_SQ01_ITEM", 13);
			await dialog.Msg("PILGRIM411_SQ_01_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

