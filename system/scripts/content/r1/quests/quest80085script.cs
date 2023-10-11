//--- Melia Script -----------------------------------------------------------
// Dirty Tricks (3)
//--- Description -----------------------------------------------------------
// Quest to Attend Dominikas' ritual.
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

[QuestScript(80085)]
public class Quest80085Script : QuestScript
{
	protected override void Load()
	{
		SetId(80085);
		SetName("Dirty Tricks (3)");
		SetDescription("Attend Dominikas' ritual");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY_35_3_SQ_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_7"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));

		AddDialogHook("ABBEY_35_3_DOMINIKAS_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY_35_4_SQ_1");
	}
}

