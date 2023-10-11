//--- Melia Script -----------------------------------------------------------
// Mission Initiated [Schwarzer Reiter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Schwarzer Reiter Master.
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

[QuestScript(90160)]
public class Quest90160Script : QuestScript
{
	protected override void Load()
	{
		SetId(90160);
		SetName("Mission Initiated [Schwarzer Reiter Advancement]");
		SetDescription("Talk to the Schwarzer Reiter Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SCHWARZEREITER_8_1_ST", "JOB_SCHWARZEREITER_8_1", "I am ready.", "I think I need some more time."))
		{
			case 1:
				await dialog.Msg("JOB_SCHWARZEREITER_8_1_AG");
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

		if (character.Inventory.HasItem("JOB_SCHWARZEREITER_8_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_SCHWARZEREITER_8_1_ITEM", 10);
			await dialog.Msg("JOB_SCHWARZEREITER_8_1_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

