//--- Melia Script -----------------------------------------------------------
// Mysterious Well
//--- Description -----------------------------------------------------------
// Quest to Go to the old well.
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

[QuestScript(20287)]
public class Quest20287Script : QuestScript
{
	protected override void Load()
	{
		SetId(20287);
		SetName("Mysterious Well");
		SetDescription("Go to the old well");

		AddPrerequisite(new LevelPrerequisite(52));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("COLLECT_101", 1));
		AddReward(new ItemReward("HUEVILLAGE_book03", 1));
		AddReward(new ItemReward("Vis", 936));

		AddDialogHook("HUEVILLAGE_58_3_SQ01_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_SQ01_NPC01", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("HUEVILLAGE_58_3_SQ01_BUCKET", 1) && character.Inventory.HasItem("HUEVILLAGE_58_3_SQ01_ROPE", 1))
		{
			character.Inventory.RemoveItem("HUEVILLAGE_58_3_SQ01_BUCKET", 1);
			character.Inventory.RemoveItem("HUEVILLAGE_58_3_SQ01_ROPE", 1);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You found someone's keepsake in the well!");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

