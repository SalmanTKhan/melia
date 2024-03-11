//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Route (3)
//--- Description -----------------------------------------------------------
// Quest to Light up the Bonfires.
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

[QuestScript(4881)]
public class Quest4881Script : QuestScript
{
	protected override void Load()
	{
		SetId(4881);
		SetName("Bonfire of the Patrol Route (3)");
		SetDescription("Light up the Bonfires");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("SUCH_POINT_01"));

		AddDialogHook("KATYN_SUCH_POINT_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

