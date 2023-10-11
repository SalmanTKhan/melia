//--- Melia Script -----------------------------------------------------------
// Trace Race (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Diena.
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

[QuestScript(90146)]
public class Quest90146Script : QuestScript
{
	protected override void Load()
	{
		SetId(90146);
		SetName("Trace Race (7)");
		SetDescription("Talk to Demon Lord Diena");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_DCAPITAL_20_6_SQ_70_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(295));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_ITEM2", 1) && character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_ITEM4", 1) && character.Inventory.HasItem("F_DCAPITAL_20_5_SQ_ITEM5", 1))
		{
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_ITEM2", 1);
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_ITEM4", 1);
			character.Inventory.RemoveItem("F_DCAPITAL_20_5_SQ_ITEM5", 1);
			await dialog.Msg("F_DCAPITAL_20_6_SQ_70_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

