//--- Melia Script -----------------------------------------------------------
// Cyclops' Attack in the Crystal Mine
//--- Description -----------------------------------------------------------
// Quest to Defeat Cyclops in the Crystal Mine.
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

[QuestScript(4471)]
public class Quest4471Script : QuestScript
{
	protected override void Load()
	{
		SetId(4471);
		SetName("Cyclops' Attack in the Crystal Mine");
		SetDescription("Defeat Cyclops in the Crystal Mine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_1_CRYSTAL_10_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(17));

		AddObjective("kill0", "Kill 1 Cyclops", new KillObjective(1, MonsterId.Boss_Strongholder));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Drug_SP1_Q", 15));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("MINE_1_CRYSTAL_10", "BeforeStart", BeforeStart);
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

