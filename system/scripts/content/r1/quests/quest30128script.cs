//--- Melia Script -----------------------------------------------------------
// Trade Route Locked Chest
//--- Description -----------------------------------------------------------
// Quest to Look inside the locked chest.
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

[QuestScript(30128)]
public class Quest30128Script : QuestScript
{
	protected override void Load()
	{
		SetId(30128);
		SetName("Trade Route Locked Chest");
		SetDescription("Look inside the locked chest");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Sutatis Trade Route Key", new CollectItemObjective("PILGRIM312_SQ_08_ITEM", 1));
		AddDrop("PILGRIM312_SQ_08_ITEM", 1.5f, 58138, 58146, 58147);

		AddDialogHook("PILGRIM312_SQ_08_BOX", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_SQ_08_BOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

