//--- Melia Script -----------------------------------------------------------
// Corrupted Tombstones
//--- Description -----------------------------------------------------------
// Quest to Talk to Albinas.
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

[QuestScript(41010)]
public class Quest41010Script : QuestScript
{
	protected override void Load()
	{
		SetId(41010);
		SetName("Corrupted Tombstones");
		SetDescription("Talk to Albinas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_36_2_SQ_010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(106));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_SQ_010_TRIGGER", "BeforeStart", BeforeStart);
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

