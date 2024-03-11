//--- Melia Script -----------------------------------------------------------
// Epitaph at Dykyne Fork on the right
//--- Description -----------------------------------------------------------
// Quest to Check the Epitaph.
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

[QuestScript(19340)]
public class Quest19340Script : QuestScript
{
	protected override void Load()
	{
		SetId(19340);
		SetName("Epitaph at Dykyne Fork on the right");
		SetDescription("Check the Epitaph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS29_MQ4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 7 Zinutekas(s)", new KillObjective(7, MonsterId.Zinutekas));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("ROKAS29_SLATE4", 1));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("ROKAS29_MQ_DEVICE4", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_DEVICE4", "BeforeEnd", BeforeEnd);
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

