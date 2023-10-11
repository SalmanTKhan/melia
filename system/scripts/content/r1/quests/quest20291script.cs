//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Road (1)
//--- Description -----------------------------------------------------------
// Quest to Light up the Patrol's Bonfires that were extinguished.
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

[QuestScript(20291)]
public class Quest20291Script : QuestScript
{
	protected override void Load()
	{
		SetId(20291);
		SetName("Bonfire of the Patrol Road (1)");
		SetDescription("Light up the Patrol's Bonfires that were extinguished");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("SUCH_POINT_01"));

		AddDialogHook("KATYN_SUCH_POINT_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

