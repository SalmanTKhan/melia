//--- Melia Script -----------------------------------------------------------
// Stolen Food Supplies
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Edgar.
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

[QuestScript(50005)]
public class Quest50005Script : QuestScript
{
	protected override void Load()
	{
		SetId(50005);
		SetName("Stolen Food Supplies");
		SetDescription("Talk to Soldier Edgar");

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_14"));

		AddObjective("collect0", "Collect 10 Miners' Village Food(s)", new CollectItemObjective("TOWN_PROVISIONS", 10));
		AddDrop("TOWN_PROVISIONS", 10f, "Goblin_Spear");

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 143));

		AddDialogHook("SIAULIAIOUT_SOLDIRE_SQ32", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_SOLDIRE_SQ32", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_32_SELECT01", "SOUT_Q_32", "I'll get back the food supplies from the Vubbes", "Sorry, I'm busy"))
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

		if (character.Inventory.HasItem("TOWN_PROVISIONS", 10))
		{
			character.Inventory.RemoveItem("TOWN_PROVISIONS", 10);
			await dialog.Msg("SOUT_Q_32_SUCC01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

