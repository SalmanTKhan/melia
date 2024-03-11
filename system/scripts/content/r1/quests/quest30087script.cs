//--- Melia Script -----------------------------------------------------------
// Sticky [Quarrel Shooter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Submaster.
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

[QuestScript(30087)]
public class Quest30087Script : QuestScript
{
	protected override void Load()
	{
		SetId(30087);
		SetName("Sticky [Quarrel Shooter Advancement]");
		SetDescription("Talk to the Quarrel Shooter Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_QUARRELSHOOTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_QUARRELSHOOTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_QUARRELSHOOTER_3_1_select", "JOB_2_QUARRELSHOOTER_3_1", "I'll help you", "I will come back later"))
		{
			case 1:
				await dialog.Msg("JOB_2_QUARRELSHOOTER_3_1_agree");
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

		if (character.Inventory.HasItem("JOB_2_QUARRELSHOOTER_3_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_2_QUARRELSHOOTER_3_1_ITEM", 10);
			await dialog.Msg("JOB_2_QUARRELSHOOTER_3_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

