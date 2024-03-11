//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vakarine.
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

[QuestScript(60027)]
public class Quest60027Script : QuestScript
{
	protected override void Load()
	{
		SetId(60027);
		SetName("The Dimensional Crack (5)");
		SetDescription("Talk to Goddess Vakarine");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_04"));

		AddObjective("collect0", "Collect 5 Sealing Token(s)", new CollectItemObjective("VPRISON515_MQ_05_ITEM", 5));
		AddDrop("VPRISON515_MQ_05_ITEM", 100f, 57720, 400442, 57718);

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("VPRISON515_MQ_05_ITEM", 5))
		{
			character.Inventory.RemoveItem("VPRISON515_MQ_05_ITEM", 5);
			await dialog.Msg("VPRISON515_MQ_05_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

