//--- Melia Script -----------------------------------------------------------
// Unexpected Encounter (2)
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

[QuestScript(91219)]
public class Quest91219Script : QuestScript
{
	protected override void Load()
	{
		SetId(91219);
		SetName("Unexpected Encounter (2)");
		SetDescription("Head in the direction of the compass on Galeed Plateau");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP16_1_ROKAS_36_1_MQ9_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_ROKAS_36_1_MQ8"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
		AddReward(new ItemReward("EP16_1_ROKAS_36_1_MQ9_ITEM", 1));

		AddDialogHook("EP16_1_ROKAS_36_1_MQ9_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_ROKAS_36_1_MQ9_NPC", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_EP16_1_ROKAS_36_1_MQ9_TAKE_ITEM;
		dialog.HideNPC("EP16_1_ROKAS_36_1_MQ9_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

