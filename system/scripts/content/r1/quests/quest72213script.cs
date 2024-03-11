//--- Melia Script -----------------------------------------------------------
// The Final Battle (5)
//--- Description -----------------------------------------------------------
// Quest to Defeat the Head of the Schaffenstar Ignas.
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

[QuestScript(72213)]
public class Quest72213Script : QuestScript
{
	protected override void Load()
	{
		SetId(72213);
		SetName("The Final Battle (5)");
		SetDescription("Defeat the Head of the Schaffenstar Ignas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_92_MQ_50_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(386));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_40"));

		AddObjective("kill0", "Kill 1 Ignas", new KillObjective(1, MonsterId.Boss_Ignas_Q1));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20458));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("STARTOWER_92_MQ_50_DLG1");
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("STARTOWER_92_MQ_60");
	}
}

