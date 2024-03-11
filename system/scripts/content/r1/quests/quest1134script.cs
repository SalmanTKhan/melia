//--- Melia Script -----------------------------------------------------------
// Mystery of Cold Iron [Cryomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(1134)]
public class Quest1134Script : QuestScript
{
	protected override void Load()
	{
		SetId(1134);
		SetName("Mystery of Cold Iron [Cryomancer Advancement]");
		SetDescription("Talk to the Cryomancer Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("collect0", "Collect 10 Varb Hard Shell(s)", new CollectItemObjective("JOB_CRYOMANCER3_1_ITEM1", 10));
		AddObjective("collect1", "Collect 10 Zinutekas Strong Horn(s)", new CollectItemObjective("JOB_CRYOMANCER3_1_ITEM2", 10));
		AddDrop("JOB_CRYOMANCER3_1_ITEM1", 10f, "varv");
		AddDrop("JOB_CRYOMANCER3_1_ITEM2", 10f, "zinutekas");

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CRYOMANCER3_1_select1", "JOB_CRYOMANCER3_1", "I accept the conditions", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_CRYOMANCER3_1_agree1");
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

		if (character.Inventory.HasItem("JOB_CRYOMANCER3_1_ITEM1", 10) && character.Inventory.HasItem("JOB_CRYOMANCER3_1_ITEM2", 10))
		{
			character.Inventory.RemoveItem("JOB_CRYOMANCER3_1_ITEM1", 10);
			character.Inventory.RemoveItem("JOB_CRYOMANCER3_1_ITEM2", 10);
			await dialog.Msg("JOB_CRYOMANCER3_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

