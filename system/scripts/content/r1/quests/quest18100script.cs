//--- Melia Script -----------------------------------------------------------
// Searching for Goddess Saule
//--- Description -----------------------------------------------------------
// Quest to Search the portal in Veja Ravine.
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

[QuestScript(18100)]
public class Quest18100Script : QuestScript
{
	protected override void Load()
	{
		SetId(18100);
		SetName("Searching for Goddess Saule");
		SetDescription("Search the portal in Veja Ravine");

		AddPrerequisite(new LevelPrerequisite(46));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_10_AFTER"));

		AddObjective("collect0", "Collect 7 Tanu's Purifying Stone(s)", new CollectItemObjective("HUEVILLAGE_58_1_MQ01_ITEM1", 7));
		AddDrop("HUEVILLAGE_58_1_MQ01_ITEM1", 10f, "Tanu");

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 690));

		AddDialogHook("HUEVILLAGE_58_1_MQ01_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_1_MQ01_select", "HUEVILLAGE_58_1_MQ01", "I'll purify the pond", "About Goddess Saule", "Think of another way"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_1_MQ01_agree");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the cable car to move to across Zvelgian Vacant Lot", 8);
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("HUEVILLAGE_58_1_MQ01_add");
				break;
		}

		return HookResult.Break;
	}
}

