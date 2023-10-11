//--- Melia Script -----------------------------------------------------------
// Location of the Metal Plate (3)
//--- Description -----------------------------------------------------------
// Quest to Hand over the Metal Plate to Justas.
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

[QuestScript(40702)]
public class Quest40702Script : QuestScript
{
	protected override void Load()
	{
		SetId(40702);
		SetName("Location of the Metal Plate (3)");
		SetDescription("Hand over the Metal Plate to Justas");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_041"));

		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS37_3_SQ_042_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

