//--- Melia Script -----------------------------------------------------------
// The Trial of Jurate
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Jurate at the Cranto Coast.
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

[QuestScript(91216)]
public class Quest91216Script : QuestScript
{
	protected override void Load()
	{
		SetId(91216);
		SetName("The Trial of Jurate");
		SetDescription("Talk to Goddess Jurate at the Cranto Coast");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP16_1_CORAL_32_1_MQ6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_CORAL_32_1_MQ5"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP16_1_CORAL_32_1_MQ6_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_CORAL_32_1_MQ6_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP16_1_CORAL_32_1_MQ6_NPC_DLG_1", "EP16_1_CORAL_32_1_MQ6", "I'm ready.", "End of conversation."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("EP16_1_CORAL_32_1_MQ6_NPC");
		dialog.UnHideNPC("EP16_1_CORAL_32_1_MQ7_NPC");
		// Func/SCR_EP16_1_CORAL_32_1_MQ6_NPC_HIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

