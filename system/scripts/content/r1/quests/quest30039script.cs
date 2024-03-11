//--- Melia Script -----------------------------------------------------------
// The Past of the Crystal Mine [Alchemist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas.
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

[QuestScript(30039)]
public class Quest30039Script : QuestScript
{
	protected override void Load()
	{
		SetId(30039);
		SetName("The Past of the Crystal Mine [Alchemist Advancement]");
		SetDescription("Talk to Vaidotas");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ALCHEMIST_6_1_select", "JOB_ALCHEMIST_6_1", "I'll help you", "I'll wait then"))
		{
			case 1:
				await dialog.Msg("JOB_ALCHEMIST_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_ALCHEMIST_6_1_ITEM_1", 40) && character.Inventory.HasItem("JOB_ALCHEMIST_6_1_ITEM_3", 40) && character.Inventory.HasItem("JOB_ALCHEMIST_6_1_ITEM_2", 40))
		{
			character.Inventory.RemoveItem("JOB_ALCHEMIST_6_1_ITEM_1", 40);
			character.Inventory.RemoveItem("JOB_ALCHEMIST_6_1_ITEM_3", 40);
			character.Inventory.RemoveItem("JOB_ALCHEMIST_6_1_ITEM_2", 40);
			await dialog.Msg("JOB_ALCHEMIST_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

