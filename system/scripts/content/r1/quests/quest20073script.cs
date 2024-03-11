//--- Melia Script -----------------------------------------------------------
// Why the Owl Sculpture Fell
//--- Description -----------------------------------------------------------
// Quest to Inspect the Destroyed Owl Sculpture.
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

[QuestScript(20073)]
public class Quest20073Script : QuestScript
{
	protected override void Load()
	{
		SetId(20073);
		SetName("Why the Owl Sculpture Fell");
		SetDescription("Inspect the Destroyed Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST3_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Soggy Mushwort", new KillObjective(1, MonsterId.Boss_Mushwort));

		AddReward(new ExpReward(120624, 120624));
		AddReward(new ItemReward("expCard7", 2));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("KATYN13_ADDQUEST3_NPC", "BeforeStart", BeforeStart);
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

