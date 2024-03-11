//--- Melia Script -----------------------------------------------------------
// [Weekly] Conquest - Remnants of Bernice
//--- Description -----------------------------------------------------------
// Quest to Clear Remnants of Bernice Stage 20 or above.
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

[QuestScript(510008)]
public class Quest510008Script : QuestScript
{
	protected override void Load()
	{
		SetId(510008);
		SetName("[Weekly] Conquest - Remnants of Bernice");
		SetDescription("Clear Remnants of Bernice Stage 20 or above");

		AddPrerequisite(new LevelPrerequisite(458));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

