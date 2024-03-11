//--- Melia Script -----------------------------------------------------------
// Death as a Human (1)
//--- Description -----------------------------------------------------------
// Quest to Go to the Central Surveillance Area.
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

[QuestScript(91070)]
public class Quest91070Script : QuestScript
{
	protected override void Load()
	{
		SetId(91070);
		SetName("Death as a Human (1)");
		SetDescription("Go to the Central Surveillance Area");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON3_MQ_7_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_6"));

		AddObjective("kill0", "Kill 1 Lunatic Marnox", new KillObjective(1, MonsterId.Boss_Insane_Marnoks));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_5", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("BalloonText/EP13_2_DPRISON3_MQ_7_DLG1/5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

