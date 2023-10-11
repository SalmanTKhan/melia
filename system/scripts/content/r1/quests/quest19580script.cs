//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Curse
//--- Description -----------------------------------------------------------
// Quest to Spoiled Tree Root Crystal at the right side of the Pilgrim's Tomb.
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

[QuestScript(19580)]
public class Quest19580Script : QuestScript
{
	protected override void Load()
	{
		SetId(19580);
		SetName("Curse of Sloth - Curse");
		SetDescription("Spoiled Tree Root Crystal at the right side of the Pilgrim's Tomb");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM47_SQ_040_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 1 Cactusvel", new KillObjective(1, MonsterId.Boss_Cactusvel_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST04", "BeforeStart", BeforeStart);
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

