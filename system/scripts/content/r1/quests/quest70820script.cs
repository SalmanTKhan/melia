//--- Melia Script -----------------------------------------------------------
// Prepare food for the refugees
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Mylija.
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

[QuestScript(70820)]
public class Quest70820Script : QuestScript
{
	protected override void Load()
	{
		SetId(70820);
		SetName("Prepare food for the refugees");
		SetDescription("Talk to Refugee Mylija");

		AddPrerequisite(new LevelPrerequisite(319));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_01_start", "MAPLE23_2_SQ01", "Say that you will collect it", "Refuse as you are too busy"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_01_agree");
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

		if (character.Inventory.HasItem("MAPLE23_2_SQ01_ITEM", 8))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ01_ITEM", 8);
			await dialog.Msg("MAPLE232_SQ_01_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

