//--- Melia Script -----------------------------------------------------------
// Story of the Owl Sculpture
//--- Description -----------------------------------------------------------
// Quest to Inspect the Destroyed Owl Sculpture.
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

[QuestScript(20071)]
public class Quest20071Script : QuestScript
{
	protected override void Load()
	{
		SetId(20071);
		SetName("Story of the Owl Sculpture");
		SetDescription("Inspect the Destroyed Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 5 Green Pokuborn(s) or High Vubbe(s)", new KillObjective(5, 400084, 41405));

		AddReward(new ExpReward(60312, 60312));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("KATYN13_ADDQUEST1_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

