//--- Melia Script -----------------------------------------------------------
// Holy Pond's Merregina
//--- Description -----------------------------------------------------------
// Quest to Check out Holy Pond.
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

[QuestScript(18170)]
public class Quest18170Script : QuestScript
{
	protected override void Load()
	{
		SetId(18170);
		SetName("Holy Pond's Merregina");
		SetDescription("Check out Holy Pond");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_1_SQ03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(46));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ01"), new CompletedPrerequisite("HUEVILLAGE_58_1_MQ02"));

		AddObjective("kill0", "Kill 1 Merregina", new KillObjective(1, MonsterId.Boss_Merregina));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("Vis", 690));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Drug_SP1_Q", 30));

		AddDialogHook("HUEVILLAGE_58_1_MQ02_NPC", "BeforeStart", BeforeStart);
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

