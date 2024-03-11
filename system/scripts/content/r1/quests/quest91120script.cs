//--- Melia Script -----------------------------------------------------------
// Left Front (2)
//--- Description -----------------------------------------------------------
// Quest to Continue Towards Left Front.
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

[QuestScript(91120)]
public class Quest91120Script : QuestScript
{
	protected override void Load()
	{
		SetId(91120);
		SetName("Left Front (2)");
		SetDescription("Continue Towards Left Front");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE5_MQ_4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(468));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_3"));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_4_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_4_HIDDEN", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_1_FCASTLE5_MQ_5");
	}
}

