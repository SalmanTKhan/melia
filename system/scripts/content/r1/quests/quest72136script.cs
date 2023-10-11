//--- Melia Script -----------------------------------------------------------
// Shield Over Flowers (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(72136)]
public class Quest72136Script : QuestScript
{
	protected override void Load()
	{
		SetId(72136);
		SetName("Shield Over Flowers (1)");
		SetDescription("Talk to the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 7 Coarse Bark(s)", new CollectItemObjective("WOODEN_SHIELD_PART", 7));
		AddDrop("WOODEN_SHIELD_PART", 10f, "Yognome");

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_HIGHLANDER1_1_DLG1", "MASTER_HIGHLANDER1_1", "What is the mission?", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HIGHLANDER2_1_prog1");
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

		if (character.Inventory.HasItem("WOODEN_SHIELD_PART", 7))
		{
			character.Inventory.RemoveItem("WOODEN_SHIELD_PART", 7);
			await dialog.Msg("JOB_HIGHLANDER2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

