//--- Melia Script -----------------------------------------------------------
// The true culprit
//--- Description -----------------------------------------------------------
// Quest to Moving to Mova Wilderness with Monk Dorma.
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

[QuestScript(70551)]
public class Quest70551Script : QuestScript
{
	protected override void Load()
	{
		SetId(70551);
		SetName("The true culprit");
		SetDescription("Moving to Mova Wilderness with Monk Dorma");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_PILGRIM41_4_SQ12_TRACKSTART", "None");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ11"));

		AddObjective("kill0", "Kill 3 Brown Nuka(s)", new KillObjective(3, MonsterId.Nuka_Brown));

		AddDialogHook("PILGRIM414_SQ_12", "BeforeStart", BeforeStart);
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
		character.Quests.Start("PILGRIM41_4_SQ13");
	}
}

