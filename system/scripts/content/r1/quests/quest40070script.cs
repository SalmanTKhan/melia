//--- Melia Script -----------------------------------------------------------
// Working on the Landfill (1)
//--- Description -----------------------------------------------------------
// Quest to Go to Sergeant Tadas.
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

[QuestScript(40070)]
public class Quest40070Script : QuestScript
{
	protected override void Load()
	{
		SetId(40070);
		SetName("Working on the Landfill (1)");
		SetDescription("Go to Sergeant Tadas");

		AddPrerequisite(new LevelPrerequisite(84));

		AddObjective("collect0", "Collect 4 Strong Rope(s)", new CollectItemObjective("FARM47_4_SQ_010_ITEM_1", 4));
		AddDrop("FARM47_4_SQ_010_ITEM_1", 5f, 57348, 400984, 57608);

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_TADAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_TADAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_010_ST", "FARM47_4_SQ_010", "I'll do it", "About why the Revelators are treated well", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_010_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_4_SQ_010_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM47_4_SQ_010_ITEM_1", 4))
		{
			character.Inventory.RemoveItem("FARM47_4_SQ_010_ITEM_1", 4);
			await dialog.Msg("FARM47_4_SQ_010_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

