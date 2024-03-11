//--- Melia Script -----------------------------------------------------------
// Purification Agent
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Tulis.
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

[QuestScript(50164)]
public class Quest50164Script : QuestScript
{
	protected override void Load()
	{
		SetId(50164);
		SetName("Purification Agent");
		SetDescription("Talk to Wizard Tulis");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ7"));

		AddObjective("collect0", "Collect 8 Tini Salivary Gland(s)", new CollectItemObjective("TABLELAND71_SUBQ8ITEM", 8));
		AddDrop("TABLELAND71_SUBQ8ITEM", 9f, "Tiny_blue");

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ8_startnpc1", "TABLELAND_71_SQ8", "I'll get it", "I can only help so much"))
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

		if (character.Inventory.HasItem("TABLELAND71_SUBQ8ITEM", 8))
		{
			character.Inventory.RemoveItem("TABLELAND71_SUBQ8ITEM", 8);
			await dialog.Msg("TABLELAND_71_SQ8_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

