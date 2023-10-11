//--- Melia Script -----------------------------------------------------------
// Open the Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to The monsters that are protecting the boxes.
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

[QuestScript(20070)]
public class Quest20070Script : QuestScript
{
	protected override void Load()
	{
		SetId(20070);
		SetName("Open the Treasure Chest");
		SetDescription("The monsters that are protecting the boxes");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "KATYN13_1_TO_OWLJUNIOR3_S1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(112));

		AddObjective("kill0", "Kill 12 High Vubbe Archer(s) or High Vubbe(s)", new KillObjective(12, 11090, 41405));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_TO_OWLJUNIOR3_S1_BOX", "BeforeStart", BeforeStart);
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

