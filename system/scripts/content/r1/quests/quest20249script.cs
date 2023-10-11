//--- Melia Script -----------------------------------------------------------
// Fight Poison with Poison (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule Believer Adele.
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

[QuestScript(20249)]
public class Quest20249Script : QuestScript
{
	protected override void Load()
	{
		SetId(20249);
		SetName("Fight Poison with Poison (1)");
		SetDescription("Talk to Goddess Saule Believer Adele");

		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("collect0", "Collect 5 Velwriggler Claw(s)", new CollectItemObjective("THORN19_MQ05_POWDER", 5));
		AddDrop("THORN19_MQ05_POWDER", 6f, "Velwriggler");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("THORN19_BELIEVER02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN19_BELIEVER02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ05_select01", "THORN19_MQ05", "I think that's a good idea", "About the Believers", "Doesn't sound so good"))
		{
			case 1:
				await dialog.Msg("THORN19_MQ05_startnpc01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN19_MQ05_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("THORN19_MQ05_POWDER", 5))
		{
			character.Inventory.RemoveItem("THORN19_MQ05_POWDER", 5);
			await dialog.Msg("THORN19_MQ05_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

