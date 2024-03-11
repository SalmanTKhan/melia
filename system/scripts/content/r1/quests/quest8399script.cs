//--- Melia Script -----------------------------------------------------------
// Swordsman's Path [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Swordsman Master.
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

[QuestScript(8399)]
public class Quest8399Script : QuestScript
{
	protected override void Load()
	{
		SetId(8399);
		SetName("Swordsman's Path [Swordsman Advancement]");
		SetDescription("Talk to the Swordsman Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 10 Red Kepa Skin(s)", new CollectItemObjective("JOB_SWORDMAN1_ITEM", 10));
		AddDrop("JOB_SWORDMAN1_ITEM", 8f, "Onion_Red");

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SWORDMAN1_01", "JOB_SWORDMAN1", "I'll gather the Red Kepa peels.", "Decline"))
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

		if (character.Inventory.HasItem("JOB_SWORDMAN1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_SWORDMAN1_ITEM", 10);
			await dialog.Msg("JOB_SWORDMAN1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

