//--- Melia Script -----------------------------------------------------------
// Ominous Red Crystal (3)
//--- Description -----------------------------------------------------------
// Quest to Join Pajauta.
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

[QuestScript(91140)]
public class Quest91140Script : QuestScript
{
	protected override void Load()
	{
		SetId(91140);
		SetName("Ominous Red Crystal (3)");
		SetDescription("Join Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_2_DCASTLE1_MQ_7_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_6"));

		AddObjective("kill0", "Kill 6 Blickferret Swordsman(s) or Blickferret Shielder(s)", new KillObjective(6, 59742, 59743));

		AddReward(new ExpReward(2400000000, 2400000000));
		AddReward(new ItemReward("Vis", 60490));

		AddDialogHook("EP14_2_DCASTLE1_MQ_7_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_PAJAUTA2", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("EP14_2_DCASTLE1_MQ_7_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_8");
	}
}

