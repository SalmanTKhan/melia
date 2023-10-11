//--- Melia Script -----------------------------------------------------------
// Past of the Crystal Mine
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas.
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

[QuestScript(72158)]
public class Quest72158Script : QuestScript
{
	protected override void Load()
	{
		SetId(72158);
		SetName("Past of the Crystal Mine");
		SetDescription("Talk to Vaidotas");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("MASTER_CHRONO1"));

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_ALCHEMIST1_DLG1", "MASTER_ALCHEMIST1", "I'll help you", "I'll wait then"))
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
			await dialog.Msg("MASTER_ALCHEMIST1_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

