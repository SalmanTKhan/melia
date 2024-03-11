//--- Melia Script -----------------------------------------------------------
// Destroy the 2nd Magic Suppressor
//--- Description -----------------------------------------------------------
// Quest to Destroy Helgasercle's 2nd Magic Suppressor.
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

[QuestScript(8494)]
public class Quest8494Script : QuestScript
{
	protected override void Load()
	{
		SetId(8494);
		SetName("Destroy the 2nd Magic Suppressor");
		SetDescription("Destroy Helgasercle's 2nd Magic Suppressor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_PRO"));

		AddObjective("kill0", "Kill 1 Magic Suppressor", new KillObjective(1, MonsterId.Spell_Suppressors));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_MQ_02_D", "BeforeStart", BeforeStart);
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

