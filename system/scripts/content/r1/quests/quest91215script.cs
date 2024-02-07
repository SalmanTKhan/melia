//--- Melia Script -----------------------------------------------------------
// Goddess Jurate
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Jurate in Cranto Coast.
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

[QuestScript(91215)]
public class Quest91215Script : QuestScript
{
	protected override void Load()
	{
		SetId(91215);
		SetName("Goddess Jurate");
		SetDescription("Talk to Goddess Jurate in Cranto Coast");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_CORAL_32_1_MQ4"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP16_1_CORAL_32_1_MQ5_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP16_1_CORAL_32_1_MQ5_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("EP16_1_CORAL_32_1_MQ5_NPC");
		// Func/SCR_EP16_1_CORAL_32_1_MQ5_NPC_HIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

