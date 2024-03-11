//--- Melia Script -----------------------------------------------------------
// Dvyni Wetland's Colimencia
//--- Description -----------------------------------------------------------
// Quest to Go to Dvyni Wetland.
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

[QuestScript(20288)]
public class Quest20288Script : QuestScript
{
	protected override void Load()
	{
		SetId(20288);
		SetName("Dvyni Wetland's Colimencia");
		SetDescription("Go to Dvyni Wetland");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_3_SQ02_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(52));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_3_MQ02"));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 936));

		AddDialogHook("HUEVILLAGE_58_3_MQ02_FLOWER", "BeforeStart", BeforeStart);
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

