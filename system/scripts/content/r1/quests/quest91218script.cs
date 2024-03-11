//--- Melia Script -----------------------------------------------------------
// A New Direction
//--- Description -----------------------------------------------------------
// Quest to Head in the direction of the compass on Galeed Plateau.
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

[QuestScript(91218)]
public class Quest91218Script : QuestScript
{
	protected override void Load()
	{
		SetId(91218);
		SetName("A New Direction");
		SetDescription("Head in the direction of the compass on Galeed Plateau");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "SCR_EP16_1_ROKAS_36_1_MQ8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_CORAL_32_1_MQ7"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP16_1_ROKAS_36_1_MQ8_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_ROKAS_36_1_MQ8_HIDDEN", "BeforeEnd", BeforeEnd);
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

		dialog.UnHideNPC("EP16_1_ROKAS_36_1_MQ9_NPC");
		// Func/SCR_EP16_1_ROKAS_36_1_MQ8_NPC_UNHIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

