//--- Melia Script -----------------------------------------------------------
// Destroy the 3rd Magic Suppressor
//--- Description -----------------------------------------------------------
// Quest to Destroy Helgasercle's 3rd Magic Suppressor.
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

[QuestScript(8495)]
public class Quest8495Script : QuestScript
{
	protected override void Load()
	{
		SetId(8495);
		SetName("Destroy the 3rd Magic Suppressor");
		SetDescription("Destroy Helgasercle's 3rd Magic Suppressor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_MQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_PRO"));

		AddObjective("kill0", "Kill 1 Magic Suppressor", new KillObjective(1, MonsterId.Spell_Suppressors));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_MQ_03_D", "BeforeStart", BeforeStart);
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

