//--- Melia Script -----------------------------------------------------------
// Defeat Red Fisherman
//--- Description -----------------------------------------------------------
// Quest to Found a herd of small Gribas.
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

[QuestScript(8268)]
public class Quest8268Script : QuestScript
{
	protected override void Load()
	{
		SetId(8268);
		SetName("Defeat Red Fisherman");
		SetDescription("Found a herd of small Gribas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN14_SUB_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(114));

		AddObjective("kill0", "Kill 9 Red Fisherman(s)", new KillObjective(9, MonsterId.Fisherman_Red));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_SUB_02_MUSH", "BeforeStart", BeforeStart);
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

