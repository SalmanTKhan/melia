//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Siesta
//--- Description -----------------------------------------------------------
// Quest to Spoiled Tree Root Crystal at Pusapskritimis Shore.
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

[QuestScript(19570)]
public class Quest19570Script : QuestScript
{
	protected override void Load()
	{
		SetId(19570);
		SetName("Curse of Sloth - Siesta");
		SetDescription("Spoiled Tree Root Crystal at Pusapskritimis Shore");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM47_SQ_030_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(124));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST03", "BeforeStart", BeforeStart);
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

