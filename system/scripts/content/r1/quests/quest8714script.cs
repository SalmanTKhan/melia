//--- Melia Script -----------------------------------------------------------
// Traces of the Shadow [Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Ranger Master.
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

[QuestScript(8714)]
public class Quest8714Script : QuestScript
{
	protected override void Load()
	{
		SetId(8714);
		SetName("Traces of the Shadow [Ranger Advancement]");
		SetDescription("Go to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 10 Moya Body Fluid Sample(s)", new CollectItemObjective("JOB_RANGER4_1_ITEM", 10));
		AddDrop("JOB_RANGER4_1_ITEM", 3f, "Moya");

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RANGER4_1_01", "JOB_RANGER4_1", "Accept the request", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER4_1_AG");
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

		if (character.Inventory.HasItem("JOB_RANGER4_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_RANGER4_1_ITEM", 10);
			await dialog.Msg("JOB_RANGER4_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

