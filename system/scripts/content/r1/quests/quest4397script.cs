//--- Melia Script -----------------------------------------------------------
// Grave's Owner
//--- Description -----------------------------------------------------------
// Quest to Find the grave at the Sunset Flag Forest.
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

[QuestScript(4397)]
public class Quest4397Script : QuestScript
{
	protected override void Load()
	{
		SetId(4397);
		SetName("Grave's Owner");
		SetDescription("Find the grave at the Sunset Flag Forest");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN23_Q_7_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 1 Mushwort", new KillObjective(1, MonsterId.Boss_Mushwort_Q2));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("THORN23_Q_7_TRIGGER", "BeforeStart", BeforeStart);
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

