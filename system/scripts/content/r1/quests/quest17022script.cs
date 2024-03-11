//--- Melia Script -----------------------------------------------------------
// Hot-blooded Simon Shaw (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Simon Shaw.
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

[QuestScript(17022)]
public class Quest17022Script : QuestScript
{
	protected override void Load()
	{
		SetId(17022);
		SetName("Hot-blooded Simon Shaw (1)");
		SetDescription("Talk to Simon Shaw");

		AddPrerequisite(new LevelPrerequisite(126));

		AddObjective("collect0", "Collect 10 Flame Charm(s)", new CollectItemObjective("FTOWER45_SQ_01_01", 10));
		AddDrop("FTOWER45_SQ_01_01", 5f, "Fire_Dragon_purple");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER45_SQ_01_ST", "FTOWER45_SQ_01", "I'll help you", "I'm sorry, but I don't think I can"))
		{
			case 1:
				await dialog.Msg("FTOWER45_SQ_01_STP");
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

		if (character.Inventory.HasItem("FTOWER45_SQ_01_01", 10))
		{
			character.Inventory.RemoveItem("FTOWER45_SQ_01_01", 10);
			await dialog.Msg("FTOWER45_SQ_01_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER45_SQ_02");
	}
}

