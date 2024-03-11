//--- Melia Script -----------------------------------------------------------
// Evil Magic Circles? (1)
//--- Description -----------------------------------------------------------
// Quest to Search Vera Coast.
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

[QuestScript(80099)]
public class Quest80099Script : QuestScript
{
	protected override void Load()
	{
		SetId(80099);
		SetName("Evil Magic Circles? (1)");
		SetDescription("Search Vera Coast");

		AddPrerequisite(new LevelPrerequisite(226));

		AddDialogHook("CORAL_35_2_SQ_1_START", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

