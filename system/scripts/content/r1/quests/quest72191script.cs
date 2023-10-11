//--- Melia Script -----------------------------------------------------------
// Suspicious Bargain (1)
//--- Description -----------------------------------------------------------
// Quest to To 12F.
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

[QuestScript(72191)]
public class Quest72191Script : QuestScript
{
	protected override void Load()
	{
		SetId(72191);
		SetName("Suspicious Bargain (1)");
		SetDescription("To 12F");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_90_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(379));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_90"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("D_STARTOWER_90_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("STARTOWER_90_MQ_10_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

