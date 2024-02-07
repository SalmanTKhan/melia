//--- Melia Script -----------------------------------------------------------
// Suspicious Encounter
//--- Description -----------------------------------------------------------
// Quest to Witness Conversations Between Demon Gods and Lords.
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

[QuestScript(91211)]
public class Quest91211Script : QuestScript
{
	protected override void Load()
	{
		SetId(91211);
		SetName("Suspicious Encounter");
		SetDescription("Witness Conversations Between Demon Gods and Lords");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_EP16_1_F_NICO_81_1_MQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_6"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP16_1_F_NICO_81_1_MQ_1_HIDDEN", "BeforeStart", BeforeStart);
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

