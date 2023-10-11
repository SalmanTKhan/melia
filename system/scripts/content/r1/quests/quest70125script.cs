//--- Melia Script -----------------------------------------------------------
// The Last Material One More Time
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Natasha.
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

[QuestScript(70125)]
public class Quest70125Script : QuestScript
{
	protected override void Load()
	{
		SetId(70125);
		SetName("The Last Material One More Time");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ05"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_MQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_MQ_06_1", "THORN39_1_MQ06", "Tell him that you would gather them quickly", "Tell him that you need some time to prepare"))
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

		if (character.Inventory.HasItem("THORN39_1_MQ06_ITEM", 5))
		{
			character.Inventory.RemoveItem("THORN39_1_MQ06_ITEM", 5);
			await dialog.Msg("THORN39_1_MQ_06_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

