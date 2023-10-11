//--- Melia Script -----------------------------------------------------------
// Stop the Beholder (1)
//--- Description -----------------------------------------------------------
// Quest to Defeat Reservoir of Corruption.
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

[QuestScript(91159)]
public class Quest91159Script : QuestScript
{
	protected override void Load()
	{
		SetId(91159);
		SetName("Stop the Beholder (1)");
		SetDescription("Defeat Reservoir of Corruption");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP14_2_DCASTLE3_MQ_5_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(478));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_4"));

		AddObjective("kill0", "Kill 1 Reservoir of Corruption", new KillObjective(1, MonsterId.Boss_TransmutationSpreader_Q1));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_DCASTLE4_MQ_5_HIDDEN", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE3_MQ_6");
	}
}

