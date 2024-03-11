//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Small-sized Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 3000 small-sized monsters in Episode 13-1 area.
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

[QuestScript(510006)]
public class Quest510006Script : QuestScript
{
	protected override void Load()
	{
		SetId(510006);
		SetName("[Weekly] Annihilation - Small-sized Monster");
		SetDescription("Defeat 3000 small-sized monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 3000 Liepsna Invader(s) or Darbas Loader(s) or Vynmedis(s) or Saugumas Defender(s) or Darbas Smuggler(s)", new KillObjective(3000, 59577, 59581, 59583, 59588, 59592));

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

