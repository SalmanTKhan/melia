//--- Melia Script -----------------------------------------------------------
// Cold and pain
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Jhodan.
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

[QuestScript(70520)]
public class Quest70520Script : QuestScript
{
	protected override void Load()
	{
		SetId(70520);
		SetName("Cold and pain");
		SetDescription("Talk to Pilgrim Jhodan");

		AddPrerequisite(new LevelPrerequisite(261));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10701));

		AddDialogHook("PILGRIM412_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_01_start", "PILGRIM41_2_SQ01", "Say that you will get the hides", "Say that there is no way to help"))
		{
			case 1:
				await dialog.Msg("PILGRIM412_SQ_01_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_2_SQ01_ITEM", 8))
		{
			character.Inventory.RemoveItem("PILGRIM41_2_SQ01_ITEM", 8);
			await dialog.Msg("PILGRIM412_SQ_01_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

