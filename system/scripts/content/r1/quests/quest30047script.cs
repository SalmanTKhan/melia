//--- Melia Script -----------------------------------------------------------
// Disaster is a Great Sample [Druid Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Druid Master.
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

[QuestScript(30047)]
public class Quest30047Script : QuestScript
{
	protected override void Load()
	{
		SetId(30047);
		SetName("Disaster is a Great Sample [Druid Advancement]");
		SetDescription("Talk to the Druid Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DRUID_6_1_select", "JOB_DRUID_6_1", "I will help the task", "I'm sorry, but I don't think I can"))
		{
			case 1:
				await dialog.Msg("JOB_DRUID_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_DRUID_6_1_ITEM", 100))
		{
			character.Inventory.RemoveItem("JOB_DRUID_6_1_ITEM", 100);
			await dialog.Msg("JOB_DRUID_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

