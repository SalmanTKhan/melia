//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Route (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Patrolling Officer.
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

[QuestScript(4880)]
public class Quest4880Script : QuestScript
{
	protected override void Load()
	{
		SetId(4880);
		SetName("Bonfire of the Patrol Route (2)");
		SetDescription("Talk to the Patrolling Officer");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("SUCH_POINT_01"));

		AddDialogHook("KATYN_SUCH_POINT_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

