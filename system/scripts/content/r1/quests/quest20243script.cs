//--- Melia Script -----------------------------------------------------------
// Moses' True Feelings (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Moses Diesel.
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

[QuestScript(20243)]
public class Quest20243Script : QuestScript
{
	protected override void Load()
	{
		SetId(20243);
		SetName("Moses' True Feelings (3)");
		SetDescription("Talk to Moses Diesel");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ06"));

		AddObjective("collect0", "Collect 5 Strong Flying Frog Leather(s)", new CollectItemObjective("REMAINS39_LEATHER", 5));
		AddDrop("REMAINS39_LEATHER", 10f, "Flying_Flog");

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN39_SQ07_select01", "REMAIN39_SQ07", "Get the leather", "Not an appealing attitude so just ignore"))
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

		if (character.Inventory.HasItem("REMAINS39_LEATHER", 5))
		{
			character.Inventory.RemoveItem("REMAINS39_LEATHER", 5);
			await dialog.Msg("REMAIN39_SQ07_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

