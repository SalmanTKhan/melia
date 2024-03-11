//--- Melia Script -----------------------------------------------------------
// How to Overcome Severe Coldness
//--- Description -----------------------------------------------------------
// Quest to Talk to Baskez.
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

[QuestScript(70206)]
public class Quest70206Script : QuestScript
{
	protected override void Load()
	{
		SetId(70206);
		SetName("How to Overcome Severe Coldness");
		SetDescription("Talk to Baskez");

		AddPrerequisite(new LevelPrerequisite(212));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_1_SQ_07_1", "TABLELAND28_1_SQ07", "I will bring them for you", "Please do that yourself"))
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

		if (character.Inventory.HasItem("TABLELAND28_1_SQ07_ITEM", 8))
		{
			character.Inventory.RemoveItem("TABLELAND28_1_SQ07_ITEM", 8);
			await dialog.Msg("TABLELAND28_1_SQ_07_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

