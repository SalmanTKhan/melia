//--- Melia Script -----------------------------------------------------------
// Destroy the 4th Magic Suppressor
//--- Description -----------------------------------------------------------
// Quest to Destroy Helgasercle's 4th Magic Suppressor.
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

[QuestScript(8496)]
public class Quest8496Script : QuestScript
{
	protected override void Load()
	{
		SetId(8496);
		SetName("Destroy the 4th Magic Suppressor");
		SetDescription("Destroy Helgasercle's 4th Magic Suppressor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_MQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_PRO"));

		AddObjective("kill0", "Kill 1 Magic Suppressor", new KillObjective(1, MonsterId.Spell_Suppressors));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_MQ_04_D", "BeforeStart", BeforeStart);
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
