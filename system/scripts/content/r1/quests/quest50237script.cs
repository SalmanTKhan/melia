//--- Melia Script -----------------------------------------------------------
// The Materials for Incense [Alchemist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Alchemist Master.
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

[QuestScript(50237)]
public class Quest50237Script : QuestScript
{
	protected override void Load()
	{
		SetId(50237);
		SetName("The Materials for Incense [Alchemist Advancement]");
		SetDescription("Talk to the Alchemist Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("collect0", "Collect 25 Blue Beetow Salivary Glands(s)", new CollectItemObjective("JOB_3_ALCHEMIST_ITEM1", 25));
		AddObjective("collect1", "Collect 45 Half-Digested Grass(s)", new CollectItemObjective("JOB_3_ALCHEMIST_ITEM2", 45));
		AddObjective("collect2", "Collect 45 Akhlass Hump's Worm(s)", new CollectItemObjective("JOB_3_ALCHEMIST_ITEM3", 45));
		AddDrop("JOB_3_ALCHEMIST_ITEM1", 10f, "beetow_blue");
		AddDrop("JOB_3_ALCHEMIST_ITEM2", 10f, "rodetad");
		AddDrop("JOB_3_ALCHEMIST_ITEM3", 10f, "aklashump");

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ALCHEMIST7_1_START1", "JOB_ALCHEMIST7_1", "I will get those materials.", "Ask another alchemist about it."))
		{
			case 1:
				await dialog.Msg("JOB_ALCHEMIST7_1_AGREE1");
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

		if (character.Inventory.HasItem("JOB_3_ALCHEMIST_ITEM1", 25) && character.Inventory.HasItem("JOB_3_ALCHEMIST_ITEM2", 45) && character.Inventory.HasItem("JOB_3_ALCHEMIST_ITEM3", 45))
		{
			character.Inventory.RemoveItem("JOB_3_ALCHEMIST_ITEM1", 25);
			character.Inventory.RemoveItem("JOB_3_ALCHEMIST_ITEM2", 45);
			character.Inventory.RemoveItem("JOB_3_ALCHEMIST_ITEM3", 45);
			await dialog.Msg("JOB_ALCHEMIST7_1_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

