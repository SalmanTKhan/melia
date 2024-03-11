//--- Melia Script -----------------------------------------------------------
// [Weekly] Spearhead - Level Dungeon
//--- Description -----------------------------------------------------------
// Quest to Clear Level dungeon 10 times.
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

[QuestScript(510014)]
public class Quest510014Script : QuestScript
{
	protected override void Load()
	{
		SetId(510014);
		SetName("[Weekly] Spearhead - Level Dungeon");
		SetDescription("Clear Level dungeon 10 times");

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

