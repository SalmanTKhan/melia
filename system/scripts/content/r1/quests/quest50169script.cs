//--- Melia Script -----------------------------------------------------------
// Village Curse (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50169)]
public class Quest50169Script : QuestScript
{
	protected override void Load()
	{
		SetId(50169);
		SetName("Village Curse (4)");
		SetDescription("Talk to Village Priest Chaleims");

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ4"));

		AddObjective("collect0", "Collect 10 White Spion Essence(s)", new CollectItemObjective("TABLELAND72_SUBQ5ITEM", 10));
		AddDrop("TABLELAND72_SUBQ5ITEM", 9.5f, "Spion_white");

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ5_startnpc1", "TABLELAND_72_SQ5", "I'll go get the White Spion essence.", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("TABLELAND_72_SQ5_prog1");
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

		if (character.Inventory.HasItem("TABLELAND72_SUBQ5ITEM", 10))
		{
			character.Inventory.RemoveItem("TABLELAND72_SUBQ5ITEM", 10);
			await dialog.Msg("TABLELAND_72_SQ5_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

