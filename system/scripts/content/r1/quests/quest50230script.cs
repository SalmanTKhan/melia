//--- Melia Script -----------------------------------------------------------
// Weeding(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Kidas.
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

[QuestScript(50230)]
public class Quest50230Script : QuestScript
{
	protected override void Load()
	{
		SetId(50230);
		SetName("Weeding(1)");
		SetDescription("Talk to Priest Kidas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ3"));

		AddObjective("collect0", "Collect 9 Vilkas Salivary Glands(s)", new CollectItemObjective("BRACKEN434_SUBQ9_ITEM1", 9));
		AddDrop("BRACKEN434_SUBQ9_ITEM1", 10f, 58455, 58454, 58458);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ9_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ9_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ9_START1", "BRACKEN43_4_SQ9", "Agree to gather Vilkas salivary glands", "I will obtain them later"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_4_SQ9_AGREE1");
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

		if (character.Inventory.HasItem("BRACKEN434_SUBQ9_ITEM1", 9))
		{
			character.Inventory.RemoveItem("BRACKEN434_SUBQ9_ITEM1", 9);
			await dialog.Msg("BRACKEN43_4_SQ9_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

