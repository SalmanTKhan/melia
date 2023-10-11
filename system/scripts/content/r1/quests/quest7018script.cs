//--- Melia Script -----------------------------------------------------------
// The threat on the ground
//--- Description -----------------------------------------------------------
// Quest to Examine the rock..
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

[QuestScript(7018)]
public class Quest7018Script : QuestScript
{
	protected override void Load()
	{
		SetId(7018);
		SetName("The threat on the ground");
		SetDescription("Examine the rock.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_REXIPHER2_MBOSS_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Iltiswort", new KillObjective(1, MonsterId.Boss_Iltiswort_Q1));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Hat_628023", 1));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("ROKAS25_REXIPHER2_BOSS_STONE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_REXIPHER2_select1", "ROKAS25_REXIPHER2", "Touch it anyways", "Cancel"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

