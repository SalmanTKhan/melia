//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Road (5)
//--- Description -----------------------------------------------------------
// Quest to Light up the Bonfires.
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

[QuestScript(20292)]
public class Quest20292Script : QuestScript
{
	protected override void Load()
	{
		SetId(20292);
		SetName("Bonfire of the Patrol Road (5)");
		SetDescription("Light up the Bonfires");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SUCH_POINT_05_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("SUCH_POINT_01"));

		AddObjective("kill0", "Kill 1 Honeypin", new KillObjective(1, MonsterId.Boss_Honeypin_Q2));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("KATYN_SUCH_POINT_05", "BeforeStart", BeforeStart);
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

