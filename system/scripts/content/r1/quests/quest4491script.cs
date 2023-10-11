//--- Melia Script -----------------------------------------------------------
// Inoperable Auxiliary Purifier (3)
//--- Description -----------------------------------------------------------
// Quest to Use the Mine Compass.
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

[QuestScript(4491)]
public class Quest4491Script : QuestScript
{
	protected override void Load()
	{
		SetId(4491);
		SetName("Inoperable Auxiliary Purifier (3)");
		SetDescription("Use the Mine Compass");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_7"));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_CRYSTAL_7_ENERGY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("MINE_2_CRYSTAL_10_ITEM", 1))
		{
			character.Inventory.RemoveItem("MINE_2_CRYSTAL_10_ITEM", 1);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Magic Supply Device has been fixed{nl}Activate the Auxiliary Purifier");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Mine Compass is still pointing at District 4{nl}Go around District 4 and look for a way to remove the rust");
	}
}

