//--- Melia Script -----------------------------------------------------------
// Nothing worse than hunger
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Diane.
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

[QuestScript(70521)]
public class Quest70521Script : QuestScript
{
	protected override void Load()
	{
		SetId(70521);
		SetName("Nothing worse than hunger");
		SetDescription("Talk to Pilgrim Diane");

		AddPrerequisite(new LevelPrerequisite(261));

		AddReward(new ItemReward("Vis", 3500));

		AddDialogHook("PILGRIM412_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_02_start", "PILGRIM41_2_SQ02", "Say that you'll find something for him to eat", "Say that you don't have anything"))
		{
			case 1:
				await dialog.Msg("PILGRIM412_SQ_02_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_2_SQ02_ITEM", 30))
		{
			character.Inventory.RemoveItem("PILGRIM41_2_SQ02_ITEM", 30);
			await dialog.Msg("PILGRIM412_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

