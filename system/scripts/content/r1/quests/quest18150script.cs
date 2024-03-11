//--- Melia Script -----------------------------------------------------------
// Nugria Sanctum's Moyabruka
//--- Description -----------------------------------------------------------
// Quest to Check the Portal at Nugria Sanctum.
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

[QuestScript(18150)]
public class Quest18150Script : QuestScript
{
	protected override void Load()
	{
		SetId(18150);
		SetName("Nugria Sanctum's Moyabruka");
		SetDescription("Check the Portal at Nugria Sanctum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_1_SQ01_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(46));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ03"), new CompletedPrerequisite("HUEVILLAGE_58_1_MQ04"));

		AddObjective("kill0", "Kill 1 Moyabruka", new KillObjective(1, MonsterId.Boss_Moyabruka));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 690));

		AddDialogHook("HUEVILLAGE_58_1_PORTAL", "BeforeStart", BeforeStart);
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

