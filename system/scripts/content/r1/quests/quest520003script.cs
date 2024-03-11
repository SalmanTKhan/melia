//--- Melia Script -----------------------------------------------------------
// [Daily] Reclaim - Paupys Crossing
//--- Description -----------------------------------------------------------
// Quest to Defeat 200 monsters in normal fields of Paupys Crossing.
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

[QuestScript(520003)]
public class Quest520003Script : QuestScript
{
	protected override void Load()
	{
		SetId(520003);
		SetName("[Daily] Reclaim - Paupys Crossing");
		SetDescription("Defeat 200 monsters in normal fields of Paupys Crossing");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 200 Vynmedis(s) or Biblioteca Keeper(s) or Darbas Cleaner(s) or Darbas Leader(s)", new KillObjective(200, 59583, 59584, 59585, 59586));

		AddDialogHook("EP13_F_SIAULIAI_3_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

