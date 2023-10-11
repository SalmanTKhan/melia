//--- Melia Script -----------------------------------------------------------
// Prayer for the Souls
//--- Description -----------------------------------------------------------
// Quest to Prayer for the Regretful Souls.
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

[QuestScript(8203)]
public class Quest8203Script : QuestScript
{
	protected override void Load()
	{
		SetId(8203);
		SetName("Prayer for the Souls");
		SetDescription("Prayer for the Regretful Souls");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN72_MQ_04_MINI_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(109));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("WARP_F_KATYN_7_2", "BeforeStart", BeforeStart);
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

