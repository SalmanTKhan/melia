//--- Melia Script -----------------------------------------------------------
// Lost Material (1)
//--- Description -----------------------------------------------------------
// Quest to Check the strange sack.
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

[QuestScript(20223)]
public class Quest20223Script : QuestScript
{
	protected override void Load()
	{
		SetId(20223);
		SetName("Lost Material (1)");
		SetDescription("Check the strange sack");

		AddPrerequisite(new LevelPrerequisite(99));

		AddObjective("collect0", "Collect 7 Experimental Ingredients(s)", new CollectItemObjective("REMAIN38_SQ01_ITEM", 7));
		AddDrop("REMAIN38_SQ01_ITEM", 10f, "Long_Arm");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("REMAIN38_SQ01_ITEM", 7))
		{
			character.Inventory.RemoveItem("REMAIN38_SQ01_ITEM", 7);
			await dialog.Msg("REMAIN38_SQ01_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

