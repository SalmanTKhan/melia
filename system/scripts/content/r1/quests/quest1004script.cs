//--- Melia Script -----------------------------------------------------------
// Talk to the Scout (2)
//--- Description -----------------------------------------------------------
// Quest to Remind the Scout that there is an order to assemble to Klaipeda.
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

[QuestScript(1004)]
public class Quest1004Script : QuestScript
{
	protected override void Load()
	{
		SetId(1004);
		SetName("Talk to the Scout (2)");
		SetDescription("Remind the Scout that there is an order to assemble to Klaipeda");

		AddPrerequisite(new LevelPrerequisite(2));
		AddPrerequisite(Or(new CompletedPrerequisite("SIAUL_WEST_STATUS_TUTO_1"), new CompletedPrerequisite("SIAUL_WEST_DRASIUS1")));

		AddObjective("collect0", "Collect 5 Soldier's Belongings(s)", new CollectItemObjective("SIAUL_WEST_DRASIUS2_Bag", 5));
		AddDrop("SIAUL_WEST_DRASIUS2_Bag", 10f, "Leaf_diving");

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("Drug_SP1_Q", 3));
		AddReward(new ItemReward("Vis", 26));

		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_DRASIUS2_dlg1", "SIAUL_WEST_DRASIUS2", "I'll find your missing belongings", "I'll wait until you find it"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_DRASIUS2_dlg_a");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Check the map by pressing the M key");
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

		if (character.Inventory.HasItem("SIAUL_WEST_DRASIUS2_Bag", 5))
		{
			character.Inventory.RemoveItem("SIAUL_WEST_DRASIUS2_Bag", 5);
			await dialog.Msg("SIAUL_WEST_DRASIUS2_dlg3");
			// Func/SCR_EXPCARD_USE_TUTO_1;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

