//--- Melia Script -----------------------------------------------------------
// Protect the Royal Masoleum
//--- Description -----------------------------------------------------------
// Quest to Talk with the Royal Mausoleum Guardian.
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

[QuestScript(60172)]
public class Quest60172Script : QuestScript
{
	protected override void Load()
	{
		SetId(60172);
		SetName("Protect the Royal Masoleum");
		SetDescription("Talk with the Royal Mausoleum Guardian");

		AddPrerequisite(new LevelPrerequisite(84));

		AddObjective("collect0", "Collect 9 Guardian's Essence(s)", new CollectItemObjective("ZACHA33_RP_1_ITEM", 9));
		AddDrop("ZACHA33_RP_1_ITEM", 7.5f, 401081, 41273, 401241, 41277, 57741);

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("ZACHA33_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA33_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA33_RP_1_1", "ZACHA33_RP_1", "Yeah, I'll collect them", "Ignore"))
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

		if (character.Inventory.HasItem("ZACHA33_RP_1_ITEM", 9))
		{
			character.Inventory.RemoveItem("ZACHA33_RP_1_ITEM", 9);
			await dialog.Msg("ZACHA33_RP_1_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

