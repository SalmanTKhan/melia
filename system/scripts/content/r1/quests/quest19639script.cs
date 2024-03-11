//--- Melia Script -----------------------------------------------------------
// Raging Soul Releasing Test (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Gracius.
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

[QuestScript(19639)]
public class Quest19639Script : QuestScript
{
	protected override void Load()
	{
		SetId(19639);
		SetName("Raging Soul Releasing Test (3)");
		SetDescription("Talk to Pilgrim Gracius");

		AddPrerequisite(new LevelPrerequisite(127));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM50_SQ_028"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM50_SQ_029_ST", "PILGRIM50_SQ_029", "I will find the scripture for him", "I will leave since you helped him a lot"))
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

		if (character.Inventory.HasItem("PILGRIM50_SQ_090_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM50_SQ_090_ITEM", 1);
			await dialog.Msg("PILGRIM50_SQ_029_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

