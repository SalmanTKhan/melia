//--- Melia Script -----------------------------------------------------------
// Andale Village Priest's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Andale Village Priest.
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

[QuestScript(20284)]
public class Quest20284Script : QuestScript
{
	protected override void Load()
	{
		SetId(20284);
		SetName("Andale Village Priest's Favor (2)");
		SetDescription("Talk to the Andale Village Priest");

		AddPrerequisite(new LevelPrerequisite(52));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_3_MQ01"));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 936));

		AddDialogHook("HUEVILLAGE_58_3_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_3_MQ02_select01", "HUEVILLAGE_58_3_MQ02", "I'll try to find them", "About the Goddess Statues", "The force is enough"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_3_MQ02_agree");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Look for a Strongly Scented Soul Flower in Dvyni Wetland");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("HUEVILLAGE_58_3_MQ02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("HUEVILLAGE_58_3_MQ02_ITEM1", 1))
		{
			character.Inventory.RemoveItem("HUEVILLAGE_58_3_MQ02_ITEM1", 1);
			await dialog.Msg("HUEVILLAGE_58_3_MQ02_succ01");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Find the Village Headman");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

