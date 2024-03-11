//--- Melia Script -----------------------------------------------------------
// Evil Energy Purification [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Priest Master.
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

[QuestScript(8397)]
public class Quest8397Script : QuestScript
{
	protected override void Load()
	{
		SetId(8397);
		SetName("Evil Energy Purification [Priest Advancement]");
		SetDescription("Talk to the Priest Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 20 Imbued Evil Energy Pouch(s)", new CollectItemObjective("JOB_PRIEST1_ITEM", 20));
		AddDrop("JOB_PRIEST1_ITEM", 10f, "Goblin_Spear");

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PRIEST1_01", "JOB_PRIEST1", "I will go through the trial", "Decline"))
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

		if (character.Inventory.HasItem("JOB_PRIEST1_ITEM", 20))
		{
			character.Inventory.RemoveItem("JOB_PRIEST1_ITEM", 20);
			await dialog.Msg("JOB_PRIEST1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

