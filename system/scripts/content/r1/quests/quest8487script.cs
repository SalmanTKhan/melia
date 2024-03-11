//--- Melia Script -----------------------------------------------------------
// Immobile Security Device
//--- Description -----------------------------------------------------------
// Quest to Check the Immobile Mineloader.
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

[QuestScript(8487)]
public class Quest8487Script : QuestScript
{
	protected override void Load()
	{
		SetId(8487);
		SetName("Immobile Security Device");
		SetDescription("Check the Immobile Mineloader");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER43_MQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("kill0", "Kill 1 Mineloader", new KillObjective(1, MonsterId.Boss_Mineloader));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2856));

		AddDialogHook("FTOWER43_MQ_05_MINENPC", "BeforeStart", BeforeStart);
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

