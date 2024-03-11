//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Research (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Rexipher.
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

[QuestScript(20188)]
public class Quest20188Script : QuestScript
{
	protected override void Load()
	{
		SetId(20188);
		SetName("Historian Rexipher's Research (5)");
		SetDescription("Talk to Historian Rexipher");

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_MQ5"));

		AddObjective("collect0", "Collect 5 Hogma Tooth(s)", new CollectItemObjective("ROKAS29_MQ_TOXI", 5));
		AddDrop("ROKAS29_MQ_TOXI", 6f, 47308, 41433);

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 18031));

		AddDialogHook("ROKAS29_MQ_REXITHER6", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_REXITHERLOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_MQ6_select01", "ROKAS29_MQ6", "I'll go find it", "Decline"))
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

		if (character.Inventory.HasItem("ROKAS29_MQ_TOXI", 5))
		{
			character.Inventory.RemoveItem("ROKAS29_MQ_TOXI", 5);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You came back with the Hogma Teeth, but Rexipher is not around!");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

