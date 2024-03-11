//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (10)
//--- Description -----------------------------------------------------------
// Quest to Facing the Beholder.
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

[QuestScript(91081)]
public class Quest91081Script : QuestScript
{
	protected override void Load()
	{
		SetId(91081);
		SetName("Chasing the Preacher (10)");
		SetDescription("Facing the Beholder");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP13_2_DPRISON1_MQ_10_TRACK_1", "None");

		AddPrerequisite(new LevelPrerequisite(460));
		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_9"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_10", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("EP13_2_DPRISON1_EFFECT");
		dialog.HideNPC("EP13_2_DPRISON2_EFFECT");
		dialog.HideNPC("EP13_2_DPRISON3_EFFECT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

