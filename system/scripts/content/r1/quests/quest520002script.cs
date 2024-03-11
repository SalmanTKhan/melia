//--- Melia Script -----------------------------------------------------------
// [Daily] Reclaim - Woods of the Linked Bridges
//--- Description -----------------------------------------------------------
// Quest to Defeat 200 monsters in normal fields of the Woods of the Linked Bridges.
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

[QuestScript(520002)]
public class Quest520002Script : QuestScript
{
	protected override void Load()
	{
		SetId(520002);
		SetName("[Daily] Reclaim - Woods of the Linked Bridges");
		SetDescription("Defeat 200 monsters in normal fields of the Woods of the Linked Bridges");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 200 Darbas Carrier(s) or Darbas Loader(s) or Darbas Miner(s)", new KillObjective(200, 59580, 59581, 59582));

		AddDialogHook("EP13_F_SIAULIAI_2_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

