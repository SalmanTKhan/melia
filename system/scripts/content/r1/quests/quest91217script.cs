//--- Melia Script -----------------------------------------------------------
// Complete Compass
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Jurate at the Cranto Coast.
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

[QuestScript(91217)]
public class Quest91217Script : QuestScript
{
	protected override void Load()
	{
		SetId(91217);
		SetName("Complete Compass");
		SetDescription("Talk to Goddess Jurate at the Cranto Coast");
		SetTrack(QuestStatus.Possible, QuestStatus.Progress, "EP16_1_CORAL_32_1_MQ7_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_CORAL_32_1_MQ6"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
		AddReward(new ItemReward("EP16_1_CORAL_32_1_MQ7_ITEM", 1));

		AddDialogHook("EP16_1_CORAL_32_1_MQ7_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_CORAL_32_1_MQ7_NPC", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_EP16_1_CORAL_32_1_MQ7_TAKE_ITEM;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

