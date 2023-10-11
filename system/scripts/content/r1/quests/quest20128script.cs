//--- Melia Script -----------------------------------------------------------
// The Road Back 
//--- Description -----------------------------------------------------------
// Quest to On the road back.
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

[QuestScript(20128)]
public class Quest20128Script : QuestScript
{
	protected override void Load()
	{
		SetId(20128);
		SetName("The Road Back ");
		SetDescription("On the road back");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SIAUL_WEST_LAIMONAS3_2_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(4));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_LAIMONAS1"));

		AddObjective("kill0", "Kill 1 Mushcaria", new KillObjective(1, MonsterId.Boss_Mushcaria));

		AddReward(new ExpReward(3000, 3000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Drug_SP1_Q", 3));
		AddReward(new ItemReward("Vis", 52));

		AddDialogHook("F_SIAULIAI_WEST_EV_55_001", "BeforeStart", BeforeStart);
		AddDialogHook("F_SIAULIAI_WEST_EV_55_001", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

