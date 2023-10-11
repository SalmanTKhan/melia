//--- Melia Script -----------------------------------------------------------
// Owl Sculpture Cremation
//--- Description -----------------------------------------------------------
// Quest to Burn the destroyed fragments of the Sculptures so that the Owls can rest in peace eternally.
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

[QuestScript(20078)]
public class Quest20078Script : QuestScript
{
	protected override void Load()
	{
		SetId(20078);
		SetName("Owl Sculpture Cremation");
		SetDescription("Burn the destroyed fragments of the Sculptures so that the Owls can rest in peace eternally");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new ItemPrerequisite("KATYN13_Oil_1", 1));

		AddObjective("kill0", "Kill 30 High Vubbe(s) or High Vubbe Archer(s) or Green Pokuborn(s)", new KillObjective(30, 41405, 11090, 400084));

		AddReward(new ExpReward(60312, 60312));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("KATYN13_ADDQUEST7_NPC", "BeforeStart", BeforeStart);
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

