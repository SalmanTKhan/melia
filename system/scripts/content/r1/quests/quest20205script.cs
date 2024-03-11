//--- Melia Script -----------------------------------------------------------
// Instinct of the Treasure Hunter
//--- Description -----------------------------------------------------------
// Quest to Talk to Treasure Hunter Eden.
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

[QuestScript(20205)]
public class Quest20205Script : QuestScript
{
	protected override void Load()
	{
		SetId(20205);
		SetName("Instinct of the Treasure Hunter");
		SetDescription("Talk to Treasure Hunter Eden");

		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("collect0", "Collect 1 Fourth Tombstone Fragment", new CollectItemObjective("REMAINS37_MSTONE_04", 1));
		AddDrop("REMAINS37_MSTONE_04", 1f, "Tama");

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Drug_SP2_Q", 30));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ02_select01", "REMAIN37_SQ02", "I'll check if what Eden says is true", "Prove it yourself"))
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

		if (character.Inventory.HasItem("REMAINS37_MSTONE_04", 1))
		{
			character.Inventory.RemoveItem("REMAINS37_MSTONE_04", 1);
			await dialog.Msg("REMAIN37_SQ02_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

