//--- Melia Script -----------------------------------------------------------
// Louise's Farmland (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Louise.
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

[QuestScript(50022)]
public class Quest50022Script : QuestScript
{
	protected override void Load()
	{
		SetId(50022);
		SetName("Louise's Farmland (3)");
		SetDescription("Talk to Louise");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 8 Pink Chupaluka Fur(s)", new CollectItemObjective("SIAULIAI50_MATERIAL", 8));
		AddDrop("SIAULIAI50_MATERIAL", 7f, "Chupaluka_pink");

		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_150_select01", "SIAULIAI_50_1_SQ_150", "Accept", "Reject"))
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

		if (character.Inventory.HasItem("SIAULIAI50_MATERIAL", 8))
		{
			character.Inventory.RemoveItem("SIAULIAI50_MATERIAL", 8);
			await dialog.Msg("SIAULIAI_50_1_SQ_150_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

