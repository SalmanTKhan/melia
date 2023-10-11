//--- Melia Script -----------------------------------------------------------
// Owl Sculpture Funeral
//--- Description -----------------------------------------------------------
// Quest to Help the Owls to rest in peace eternally.
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

[QuestScript(20079)]
public class Quest20079Script : QuestScript
{
	protected override void Load()
	{
		SetId(20079);
		SetName("Owl Sculpture Funeral");
		SetDescription("Help the Owls to rest in peace eternally");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST8_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(112));
		AddPrerequisite(new CompletedPrerequisite("KATYN13_ADDQUEST4"));
		AddPrerequisite(new ItemPrerequisite("KATYN13_Oil_1", -100));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_ADDQUEST8_NPC", "BeforeStart", BeforeStart);
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

