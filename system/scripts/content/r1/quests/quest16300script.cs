//--- Melia Script -----------------------------------------------------------
// Vilna Forest: The Northern Altar Cyclops
//--- Description -----------------------------------------------------------
// Quest to Check the altar of Vilna Forest at the north side.
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

[QuestScript(16300)]
public class Quest16300Script : QuestScript
{
	protected override void Load()
	{
		SetId(16300);
		SetName("Vilna Forest: The Northern Altar Cyclops");
		SetDescription("Check the altar of Vilna Forest at the north side");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_3_SQ_01_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_3_MQ_04"));

		AddObjective("kill0", "Kill 1 Cyclops", new KillObjective(1, MonsterId.Boss_Strongholder_Q3));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("SIAULIAI_46_3_AUSTEJA_ALTAR_02", "BeforeStart", BeforeStart);
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

