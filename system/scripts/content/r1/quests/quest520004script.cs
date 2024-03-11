//--- Melia Script -----------------------------------------------------------
// [Daily] Reclaim - Issaugoti Forest
//--- Description -----------------------------------------------------------
// Quest to Defeat 200 of monsters in normal fields of Issaugoti Forest.
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

[QuestScript(520004)]
public class Quest520004Script : QuestScript
{
	protected override void Load()
	{
		SetId(520004);
		SetName("[Daily] Reclaim - Issaugoti Forest");
		SetDescription("Defeat 200 of monsters in normal fields of Issaugoti Forest");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 200 Saugumas Sentinel(s) or Saugumas Defender(s) or Saugumas Guardian(s)", new KillObjective(200, 59587, 59588, 59589));

		AddDialogHook("EP13_F_SIAULIAI_4_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

