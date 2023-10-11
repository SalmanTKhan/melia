//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Faint
//--- Description -----------------------------------------------------------
// Quest to Tree Root Crystal of Sloth at Posukis Path.
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

[QuestScript(19590)]
public class Quest19590Script : QuestScript
{
	protected override void Load()
	{
		SetId(19590);
		SetName("Curse of Sloth - Faint");
		SetDescription("Tree Root Crystal of Sloth at Posukis Path");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("collect0", "Collect 1 Tree Root Crystal Core", new CollectItemObjective("PILGRIM47_ITEM_01", 1));
		AddDrop("PILGRIM47_ITEM_01", 5f, 57281, 57280, 57492);

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM47_CRYST05", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("PILGRIM47_ITEM_01", 1))
		{
			character.Inventory.RemoveItem("PILGRIM47_ITEM_01", 1);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Found the Crystal Core and destroyed it!{nl}The corruption will now disappear!");
			await Task.Delay(500);
			dialog.HideNPC("PILGRIM47_CURSE01");
			dialog.HideNPC("PILGRIM47_CRYST05");
			dialog.HideNPC("PILGRIM47_CURSE02");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

