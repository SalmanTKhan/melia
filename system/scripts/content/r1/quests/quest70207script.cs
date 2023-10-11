//--- Melia Script -----------------------------------------------------------
// Necessities
//--- Description -----------------------------------------------------------
// Quest to Talk with Higgs.
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

[QuestScript(70207)]
public class Quest70207Script : QuestScript
{
	protected override void Load()
	{
		SetId(70207);
		SetName("Necessities");
		SetDescription("Talk with Higgs");

		AddPrerequisite(new LevelPrerequisite(212));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_1_SQ02"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_08_1", "TABLELAND28_1_SQ08", "I will look for a flint", "Why don't you look for other means?"))
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

		if (character.Inventory.HasItem("TABLELAND28_1_SQ08_ITEM", 5))
		{
			character.Inventory.RemoveItem("TABLELAND28_1_SQ08_ITEM", 5);
			await dialog.Msg("TABLELAND28_1_SQ_08_3");
			await dialog.Msg("NPCAin/TABLELAND281_SQ_08_F/ON/1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

