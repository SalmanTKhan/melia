//--- Melia Script -----------------------------------------------------------
// Naktis' Wrath
//--- Description -----------------------------------------------------------
// Quest to Enter into the Pasala Altar.
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

[QuestScript(20337)]
public class Quest20337Script : QuestScript
{
	protected override void Load()
	{
		SetId(20337);
		SetName("Naktis' Wrath");
		SetDescription("Enter into the Pasala Altar");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL56_SQ01_TRACK", "m_boss_scenario2");

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ06"));

		AddObjective("kill0", "Kill 1 Naktis", new KillObjective(1, MonsterId.Boss_Naktis));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Drug_AddStat", 1));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_SQ01", "BeforeStart", BeforeStart);
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

