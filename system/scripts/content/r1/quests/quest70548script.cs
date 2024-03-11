//--- Melia Script -----------------------------------------------------------
// Even trash has it's uses
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Dorma.
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

[QuestScript(70548)]
public class Quest70548Script : QuestScript
{
	protected override void Load()
	{
		SetId(70548);
		SetName("Even trash has it's uses");
		SetDescription("Talk to Monk Dorma");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ08"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_09_start", "PILGRIM41_4_SQ09", "Say that you will retrieve them", "Say that you hate dirty things"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_09_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_4_SQ09_ITEM", 7))
		{
			character.Inventory.RemoveItem("PILGRIM41_4_SQ09_ITEM", 7);
			await dialog.Msg("PILGRIM414_SQ_09_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

