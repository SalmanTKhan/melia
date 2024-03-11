//--- Melia Script -----------------------------------------------------------
// Unexpected Encounter
//--- Description -----------------------------------------------------------
// Quest to Go where the compass points in Cranto Coast.
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

[QuestScript(91214)]
public class Quest91214Script : QuestScript
{
	protected override void Load()
	{
		SetId(91214);
		SetName("Unexpected Encounter");
		SetDescription("Go where the compass points in Cranto Coast");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_EP16_1_CORAL_32_1_MQ4_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_SIAULIAI_WEST_MQ3"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP16_1_CORAL_32_1_MQ4_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_CORAL_32_1_MQ5_NPC", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_EP16_1_CORAL_32_1_MQ5_UNHIDE_NPC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

