//--- Melia Script -----------------------------------------------------------
// Convincing Lord Ryudhas(1)
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

[QuestScript(70823)]
public class Quest70823Script : QuestScript
{
	protected override void Load()
	{
		SetId(70823);
		SetName("Convincing Lord Ryudhas(1)");
		SetDescription("Talk to Lord Ryudhas");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ03"));

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

		switch (await dialog.Select("MAPLE232_SQ_04_start", "MAPLE23_2_SQ04", "Propose talking to Lord Joquvas", "Ask why the two lords are fighting here", "Apologies for the intrusion and step away"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_04_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("MAPLE232_SQ_04_select");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("MAPLE23_2_SQ04_ITEM", 8))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ04_ITEM", 8);
			await dialog.Msg("MAPLE232_SQ_04_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

