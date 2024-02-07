//--- Melia Script -----------------------------------------------------------
// Questionable Compass
//--- Description -----------------------------------------------------------
// Quest to Talk to the Dievdirbys Master.
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

[QuestScript(91213)]
public class Quest91213Script : QuestScript
{
	protected override void Load()
	{
		SetId(91213);
		SetName("Questionable Compass");
		SetDescription("Talk to the Dievdirbys Master");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_CATHEDRAL_MQ2"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));
		AddReward(new ItemReward("EP16_1_SIAULIAI_WEST_MQ3_ITEM", 1));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP16_1_SIAULIAI_WEST_MQ3_NPC_DLG_1", "EP16_1_SIAULIAI_WEST_MQ3", "Continue the conversation.", "Return."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP16_1_SIAULIAI_WEST_MQ3_NPC_DLG_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

