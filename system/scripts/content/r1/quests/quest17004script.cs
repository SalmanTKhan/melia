//--- Melia Script -----------------------------------------------------------
// Evidence of Bedazzlement (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Cordelier.
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

[QuestScript(17004)]
public class Quest17004Script : QuestScript
{
	protected override void Load()
	{
		SetId(17004);
		SetName("Evidence of Bedazzlement (1)");
		SetDescription("Talk to Cordelier");

		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("collect0", "Collect 10 Black Coal Powder(s)", new CollectItemObjective("FTOWER41_SQ_03_01", 10));
		AddDrop("FTOWER41_SQ_03_01", 5f, "flight_hope");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_SQ_03_ST", "FTOWER41_SQ_03", "I'll go find Black Coal Powder", "About the circumstances now", "I don't want to"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FTOWER41_SQ_03_STP");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FTOWER41_SQ_03_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER41_SQ_03_01", 10);
			await dialog.Msg("FTOWER41_SQ_03_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_SQ_04");
	}
}

