//--- Melia Script -----------------------------------------------------------
// Unknown Poison (3)
//--- Description -----------------------------------------------------------
// Quest to Collect Spring Water Venom.
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

[QuestScript(70124)]
public class Quest70124Script : QuestScript
{
	protected override void Load()
	{
		SetId(70124);
		SetName("Unknown Poison (3)");
		SetDescription("Collect Spring Water Venom");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ04"));

		AddReward(new ExpReward(3140010, 3140010));
		AddReward(new ItemReward("expCard9", 7));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("THORN39_1_MQ05_ITEM", 7))
		{
			character.Inventory.RemoveItem("THORN39_1_MQ05_ITEM", 7);
			await dialog.Msg("THORN39_1_MQ_05_1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

