//--- Melia Script -----------------------------------------------------------
// The Final Battle (6)
//--- Description -----------------------------------------------------------
// Quest to Investigate the First Observatory Telescope.
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

[QuestScript(72214)]
public class Quest72214Script : QuestScript
{
	protected override void Load()
	{
		SetId(72214);
		SetName("The Final Battle (6)");
		SetDescription("Investigate the First Observatory Telescope");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_92_MQ_60_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(386));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_50"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("D_STARTOWER_92_MQ_60_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03", "BeforeEnd", BeforeEnd);
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

		//SCR_STARTOWER_92_MQ_60_END
		await dialog.Msg("STARTOWER_92_MQ_60_DLG2");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("STARTOWER_92_MQ_70");
	}
}

