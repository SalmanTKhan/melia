//--- Melia Script -----------------------------------------------------------
// A Dark Entity
//--- Description -----------------------------------------------------------
// Quest to Check the Dark Figure on the way to the next point.
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

[QuestScript(91114)]
public class Quest91114Script : QuestScript
{
	protected override void Load()
	{
		SetId(91114);
		SetName("A Dark Entity");
		SetDescription("Check the Dark Figure on the way to the next point");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP14_1_FCASTLE4_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(466));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_5"));

		AddReward(new ExpReward(1046153856, 1046153856));

		AddDialogHook("EP14_1_FCASTLE4_MQ_6_NPC1", "BeforeStart", BeforeStart);
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
		character.Quests.Start("EP14_1_FCASTLE4_MQ_7");
	}
}

