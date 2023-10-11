//--- Melia Script -----------------------------------------------------------
// Unexpected Discovery (2)
//--- Description -----------------------------------------------------------
// Quest to Investigate the old chest.
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

[QuestScript(40290)]
public class Quest40290Script : QuestScript
{
	protected override void Load()
	{
		SetId(40290);
		SetName("Unexpected Discovery (2)");
		SetDescription("Investigate the old chest");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_2_SQ_020_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(89));

		AddObjective("collect0", "Collect 1 Small Stone Statue's Upper Body", new CollectItemObjective("FARM47_2_SQ_020_ITEM_1", 1));
		AddDrop("FARM47_2_SQ_020_ITEM_1", 10f, "TreasureBox1_1");

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1780));

		AddDialogHook("FARM47_DRUM01_D", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JOANA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

