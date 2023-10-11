//--- Melia Script -----------------------------------------------------------
// Girl in Danger
//--- Description -----------------------------------------------------------
// Quest to Go to the altar of Nugria Sanctum.
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

[QuestScript(18190)]
public class Quest18190Script : QuestScript
{
	protected override void Load()
	{
		SetId(18190);
		SetName("Girl in Danger");
		SetDescription("Go to the altar of Nugria Sanctum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_1_MQ11_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_3_MQ04"));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("HUEVILLAGE_58_1_MQ11_TRIGGER", "BeforeStart", BeforeStart);
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

