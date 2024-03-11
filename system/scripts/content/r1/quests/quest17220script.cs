//--- Melia Script -----------------------------------------------------------
// Natural Seeds
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Basil.
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

[QuestScript(17220)]
public class Quest17220Script : QuestScript
{
	protected override void Load()
	{
		SetId(17220);
		SetName("Natural Seeds");
		SetDescription("Talk to Watcher Basil");

		AddPrerequisite(new LevelPrerequisite(29));

		AddObjective("collect0", "Collect 5 Mali Seeds(s)", new CollectItemObjective("GELE572_MQ_08_ITEM", 5));
		AddDrop("GELE572_MQ_08_ITEM", 6f, "Mally");

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("GELE572_NPC_BASIL", "BeforeStart", BeforeStart);
		AddDialogHook("GELE572_NPC_BASIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE572_MQ_02_ST", "GELE572_MQ_03", "No problem", "About the Pledge", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("GELE572_MQ_02_ST_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("GELE572_MQ_08_ITEM", 5))
		{
			character.Inventory.RemoveItem("GELE572_MQ_08_ITEM", 5);
			await dialog.Msg("GELE572_MQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

