//--- Melia Script -----------------------------------------------------------
// Convincing Lord Ryudhas(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Lord Ryudhas.
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

[QuestScript(70824)]
public class Quest70824Script : QuestScript
{
	protected override void Load()
	{
		SetId(70824);
		SetName("Convincing Lord Ryudhas(2)");
		SetDescription("Talk to Lord Ryudhas");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ04"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_05_start", "MAPLE23_2_SQ05", "I'll get it. ", "Say that you will leave it to his men"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_05_agree");
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

		if (character.Inventory.HasItem("MAPLE23_2_SQ05_ITEM", 18))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ05_ITEM", 18);
			await dialog.Msg("MAPLE232_SQ_05_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

