//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (3)
//--- Description -----------------------------------------------------------
// Quest to Find Agailla Flurry's gravestones .
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

[QuestScript(20215)]
public class Quest20215Script : QuestScript
{
	protected override void Load()
	{
		SetId(20215);
		SetName("Flurry's Epitaphs (3)");
		SetDescription("Find Agailla Flurry's gravestones ");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ02"));

		AddObjective("collect0", "Collect 1 Villager's Bag", new CollectItemObjective("REMAINS39_BACKPACK", 1));
		AddDrop("REMAINS39_BACKPACK", 2f, "Zolem");

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_MQ_MONUMENT3", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_PEAPLE", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("REMAINS39_BACKPACK", 1))
		{
			character.Inventory.RemoveItem("REMAINS39_BACKPACK", 1);
			await dialog.Msg("REMAINS39_MQ03_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

