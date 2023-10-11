//--- Melia Script -----------------------------------------------------------
// Wizard Tulis' Ore Research (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Tulis.
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

[QuestScript(50161)]
public class Quest50161Script : QuestScript
{
	protected override void Load()
	{
		SetId(50161);
		SetName("Wizard Tulis' Ore Research (1)");
		SetDescription("Talk to Wizard Tulis");

		AddPrerequisite(new LevelPrerequisite(242));

		AddObjective("collect0", "Collect 10 Blue Cronewt Needler Crystal(s)", new CollectItemObjective("TABLELAND71_SUBQ5ITEM", 10));
		AddDrop("TABLELAND71_SUBQ5ITEM", 10f, "Cronewt_bow_blue");

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ5_startnpc1", "TABLELAND_71_SQ5", "What are you doing?", "Ignore"))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ5_startnpc2");
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

		if (character.Inventory.HasItem("TABLELAND71_SUBQ5ITEM", 10))
		{
			character.Inventory.RemoveItem("TABLELAND71_SUBQ5ITEM", 10);
			await dialog.Msg("TABLELAND_71_SQ5_succ1");
			// Func/TABLELAND71_SUBQ1_COMPLETE;
			await dialog.Msg("TABLELAND_71_SQ5_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

