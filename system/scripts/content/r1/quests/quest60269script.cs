//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (7)
//--- Description -----------------------------------------------------------
// Quest to Activate the Ballandans Collapsing Device.
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

[QuestScript(60269)]
public class Quest60269Script : QuestScript
{
	protected override void Load()
	{
		SetId(60269);
		SetName("The History that Will Not Be Recorded (7)");
		SetDescription("Activate the Ballandans Collapsing Device");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB484_MQ_7_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_6"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FANTASYLIB484_MQ_7_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FANTASYLIB484_MQ_7_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

