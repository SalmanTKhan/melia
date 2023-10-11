//--- Melia Script -----------------------------------------------------------
// So that they will be able to protect themselves
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Greg.
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

[QuestScript(70821)]
public class Quest70821Script : QuestScript
{
	protected override void Load()
	{
		SetId(70821);
		SetName("So that they will be able to protect themselves");
		SetDescription("Talk to Refugee Greg");

		AddPrerequisite(new LevelPrerequisite(319));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_02_start", "MAPLE23_2_SQ02", "I'll try to find them", "Say that they should run if it is too dangerous"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_02_agree");
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

		if (character.Inventory.HasItem("MAPLE23_2_SQ02_ITEM", 11))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ02_ITEM", 11);
			await dialog.Msg("MAPLE232_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

