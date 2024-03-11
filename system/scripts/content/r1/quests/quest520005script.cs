//--- Melia Script -----------------------------------------------------------
// [Daily] Reclaim - Kirtimas Forest
//--- Description -----------------------------------------------------------
// Quest to Defeat 200 of monsters in normal fields of Kirtimas Forest.
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

[QuestScript(520005)]
public class Quest520005Script : QuestScript
{
	protected override void Load()
	{
		SetId(520005);
		SetName("[Daily] Reclaim - Kirtimas Forest");
		SetDescription("Defeat 200 of monsters in normal fields of Kirtimas Forest");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 200 Elgesys Malkos(s) or Elgesys Collecter(s) or Darbas Smuggler(s) or Elgesys Guard(s)", new KillObjective(200, 59590, 59591, 59592, 59593));

		AddDialogHook("EP13_F_SIAULIAI_5_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

