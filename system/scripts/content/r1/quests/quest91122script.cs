//--- Melia Script -----------------------------------------------------------
// Right Front 
//--- Description -----------------------------------------------------------
// Quest to Join the Right Front and Help Pajauta.
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

[QuestScript(91122)]
public class Quest91122Script : QuestScript
{
	protected override void Load()
	{
		SetId(91122);
		SetName("Right Front ");
		SetDescription("Join the Right Front and Help Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE5_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(468));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_5"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_6_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_6_HIDDEN", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_PAJAUTA_SUMMON_3;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_1_FCASTLE5_MQ_7");
	}
}

