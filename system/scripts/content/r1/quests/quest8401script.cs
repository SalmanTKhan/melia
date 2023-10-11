//--- Melia Script -----------------------------------------------------------
// Proving Abilities [Archer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Master.
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

[QuestScript(8401)]
public class Quest8401Script : QuestScript
{
	protected override void Load()
	{
		SetId(8401);
		SetName("Proving Abilities [Archer Advancement]");
		SetDescription("Talk to the Archer Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 10 Jukopus Core(s)", new CollectItemObjective("JOB_ARCHER1_ITEM", 10));
		AddDrop("JOB_ARCHER1_ITEM", 6f, "Jukopus");

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ARCHER1_01", "JOB_ARCHER1", "I will take the challenge", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("JOB_ARCHER1_01_AG");
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

		if (character.Inventory.HasItem("JOB_ARCHER1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_ARCHER1_ITEM", 10);
			await dialog.Msg("JOB_ARCHER1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

