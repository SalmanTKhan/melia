//--- Melia Script -----------------------------------------------------------
// Evidence of Bedazzlement (2)
//--- Description -----------------------------------------------------------
// Quest to Evidence of Bedazzlement.
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

[QuestScript(17005)]
public class Quest17005Script : QuestScript
{
	protected override void Load()
	{
		SetId(17005);
		SetName("Evidence of Bedazzlement (2)");
		SetDescription("Evidence of Bedazzlement");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_SQ_03"));

		AddObjective("collect0", "Collect 10 Eternal Ember(s)", new CollectItemObjective("FTOWER41_SQ_04_01", 10));
		AddDrop("FTOWER41_SQ_04_01", 5f, "Fire_Dragon");

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

		switch (await dialog.Select("FTOWER41_SQ_04_ST", "FTOWER41_SQ_04", "I will bring the Eternal Ember", "Go find it yourself"))
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

		if (character.Inventory.HasItem("FTOWER41_SQ_04_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER41_SQ_04_01", 10);
			await dialog.Msg("FTOWER41_SQ_04_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_SQ_05");
	}
}

