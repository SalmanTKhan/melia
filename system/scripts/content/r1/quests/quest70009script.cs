//--- Melia Script -----------------------------------------------------------
// Big Inconvenience
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Miren.
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

[QuestScript(70009)]
public class Quest70009Script : QuestScript
{
	protected override void Load()
	{
		SetId(70009);
		SetName("Big Inconvenience");
		SetDescription("Talk to Farmer Miren");

		AddPrerequisite(new LevelPrerequisite(149));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_SQ03"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_04_1", "FARM49_1_SQ04", "I will find her luggages", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM49_1_SQ_04_2");
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

		if (character.Inventory.HasItem("FARM49_1_SQ04_ITEM", 1))
		{
			character.Inventory.RemoveItem("FARM49_1_SQ04_ITEM", 1);
			await dialog.Msg("FARM49_1_SQ_04_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

