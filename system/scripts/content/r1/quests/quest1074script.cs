//--- Melia Script -----------------------------------------------------------
// Bright Future [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Submaster.
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

[QuestScript(1074)]
public class Quest1074Script : QuestScript
{
	protected override void Load()
	{
		SetId(1074);
		SetName("Bright Future [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 1 Glizardon Leather", new CollectItemObjective("JOB_HOPLITE2_ITEM1", 1));
		AddObjective("collect1", "Collect 1 Galok Canine", new CollectItemObjective("JOB_HOPLITE2_ITEM2", 1));
		AddObjective("collect2", "Collect 6 Black Egnome Powder(s)", new CollectItemObjective("JOB_HOPLITE2_ITEM3", 6));
		AddDrop("JOB_HOPLITE2_ITEM1", 10f, "Glizardon");
		AddDrop("JOB_HOPLITE2_ITEM2", 10f, "Galok");
		AddDrop("JOB_HOPLITE2_ITEM3", 10f, "Egnome");

		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HOPLITE2_select1", "JOB_HOPLITE2", "I'll take on the assignment", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HOPLITE2_agree1");
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

		if (character.Inventory.HasItem("JOB_HOPLITE2_ITEM1", 1) && character.Inventory.HasItem("JOB_HOPLITE2_ITEM2", 1) && character.Inventory.HasItem("JOB_HOPLITE2_ITEM3", 6))
		{
			character.Inventory.RemoveItem("JOB_HOPLITE2_ITEM1", 1);
			character.Inventory.RemoveItem("JOB_HOPLITE2_ITEM2", 1);
			character.Inventory.RemoveItem("JOB_HOPLITE2_ITEM3", 6);
			await dialog.Msg("JOB_HOPLITE2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

