//--- Melia Script -----------------------------------------------------------
// [Daily] Reclaim - Lemprasa Pond
//--- Description -----------------------------------------------------------
// Quest to Defeat 200 monsters in normal fields of Lemprasa Pond.
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

[QuestScript(520001)]
public class Quest520001Script : QuestScript
{
	protected override void Load()
	{
		SetId(520001);
		SetName("[Daily] Reclaim - Lemprasa Pond");
		SetDescription("Defeat 200 monsters in normal fields of Lemprasa Pond");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 200 Liepsna Spreader(s) or Liepsna Invader(s) or Liepsna Chaser(s) or Liepsna Destroyer(s)", new KillObjective(200, 59576, 59577, 59578, 59579));

		AddDialogHook("EP13_F_SIAULIAI_1_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

