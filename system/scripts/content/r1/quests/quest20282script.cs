//--- Melia Script -----------------------------------------------------------
// Slepingas Stream's Blue Woodspirit
//--- Description -----------------------------------------------------------
// Quest to Check the Obelisk.
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

[QuestScript(20282)]
public class Quest20282Script : QuestScript
{
	protected override void Load()
	{
		SetId(20282);
		SetName("Slepingas Stream's Blue Woodspirit");
		SetDescription("Check the Obelisk");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_2_SQ03_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(49));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ04"));

		AddObjective("kill0", "Kill 1 Blue Woodspirit", new KillObjective(1, MonsterId.Boss_Woodspirit_Blue));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_OBELISK_BEFORE", "BeforeStart", BeforeStart);
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

