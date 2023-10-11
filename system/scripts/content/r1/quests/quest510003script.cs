//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Beast-type Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 2000 Beast-type Monsters in Episode 13-1 area.
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

[QuestScript(510003)]
public class Quest510003Script : QuestScript
{
	protected override void Load()
	{
		SetId(510003);
		SetName("[Weekly] Annihilation - Beast-type Monster");
		SetDescription("Defeat 2000 Beast-type Monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 2000 Darbas Carrier(s) or Darbas Miner(s) or Darbas Cleaner(s) or Darbas Leader(s) or Darbas Smuggler(s)", new KillObjective(2000, 59580, 59582, 59585, 59586, 59592));

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

