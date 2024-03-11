//--- Melia Script -----------------------------------------------------------
// The Battle
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91209)]
public class Quest91209Script : QuestScript
{
	protected override void Load()
	{
		SetId(91209);
		SetName("The Battle");
		SetDescription("Talk to Goddess Ausrine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_5_TRACK2", "None");

		AddPrerequisite(new LevelPrerequisite(495));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_4"));

		AddObjective("kill0", "Kill 1 Demon God Slogutis", new KillObjective(1, MonsterId.Boss_Slogutis_Q1));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICOPOLIS_2_MQ_5_HIDDEN_1", "BeforeStart", BeforeStart);
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

