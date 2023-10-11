//--- Melia Script -----------------------------------------------------------
// Necklace of Salvation [Cleric Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cleric Master.
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

[QuestScript(8402)]
public class Quest8402Script : QuestScript
{
	protected override void Load()
	{
		SetId(8402);
		SetName("Necklace of Salvation [Cleric Advancement]");
		SetDescription("Talk to the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 12 Green Ointment(s)", new CollectItemObjective("JOB_CLERIC1_ITEM", 12));
		AddDrop("JOB_CLERIC1_ITEM", 8f, "Goblin_Spear");

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CLERIC1_01", "JOB_CLERIC1", "I will gather the green salve", "Decline"))
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

		if (character.Inventory.HasItem("JOB_CLERIC1_ITEM", 12))
		{
			character.Inventory.RemoveItem("JOB_CLERIC1_ITEM", 12);
			await dialog.Msg("JOB_CLERIC1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

