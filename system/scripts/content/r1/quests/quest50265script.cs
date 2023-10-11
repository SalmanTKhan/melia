//--- Melia Script -----------------------------------------------------------
// My Precious Friend (2)
//--- Description -----------------------------------------------------------
// Quest to Give Your Food to the Companion.
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

[QuestScript(50265)]
public class Quest50265Script : QuestScript
{
	protected override void Load()
	{
		SetId(50265);
		SetName("My Precious Friend (2)");
		SetDescription("Give Your Food to the Companion");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_HQ2"));

		AddDialogHook("ORSHA_PETSHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

