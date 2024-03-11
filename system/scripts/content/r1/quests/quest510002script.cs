//--- Melia Script -----------------------------------------------------------
// [Weekly] Annihilation - Insect,Devil, Plant-type Monster
//--- Description -----------------------------------------------------------
// Quest to Defeat 2000 Insect, Devil, Plant-type Monsters in Episode 13-1 area.
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

[QuestScript(510002)]
public class Quest510002Script : QuestScript
{
	protected override void Load()
	{
		SetId(510002);
		SetName("[Weekly] Annihilation - Insect,Devil, Plant-type Monster");
		SetDescription("Defeat 2000 Insect, Devil, Plant-type Monsters in Episode 13-1 area");

		AddPrerequisite(new LevelPrerequisite(458));

		AddObjective("kill0", "Kill 2000 Liepsna Invader(s) or Liepsna Chaser(s) or Liepsna Destroyer(s) or Biblioteca Keeper(s) or Vynmedis(s) or Darbas Loader(s) or Saugumas Defender(s) or Elgesys Malkos(s)", new KillObjective(2000, 59577, 59578, 59579, 59584, 59583, 59581, 59588, 59590));

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

