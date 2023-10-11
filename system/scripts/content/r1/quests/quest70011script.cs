//--- Melia Script -----------------------------------------------------------
// A Good Sign
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigator Monahan.
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

[QuestScript(70011)]
public class Quest70011Script : QuestScript
{
	protected override void Load()
	{
		SetId(70011);
		SetName("A Good Sign");
		SetDescription("Talk with Investigator Monahan");

		AddPrerequisite(new LevelPrerequisite(149));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_SQ05"));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_06_1", "FARM49_1_SQ06", "Alright, I'll help you", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("FARM49_1_SQ_06_2");
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

		if (character.Inventory.HasItem("FARM49_1_SQ06_ITEM", 7))
		{
			character.Inventory.RemoveItem("FARM49_1_SQ06_ITEM", 7);
			await dialog.Msg("FARM49_1_SQ_06_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

