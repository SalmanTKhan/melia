//--- Melia Script -----------------------------------------------------------
// Storage Lamp(2)
//--- Description -----------------------------------------------------------
// Quest to Check the Blue Lamp.
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

[QuestScript(30158)]
public class Quest30158Script : QuestScript
{
	protected override void Load()
	{
		SetId(30158);
		SetName("Storage Lamp(2)");
		SetDescription("Check the Blue Lamp");

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_4"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_OBJ_3", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_OBJ_3", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("PRISON_79_MQ_5_ITEM", 5))
		{
			character.Inventory.RemoveItem("PRISON_79_MQ_5_ITEM", 5);
			dialog.UnHideNPC("PRISON_79_OBJ_3_EFFECT");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have lit the Blue Lamp{nl}Look for the Red Lamp");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

