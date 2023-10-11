//--- Melia Script -----------------------------------------------------------
// Despair and Echoes
//--- Description -----------------------------------------------------------
// Quest to Collect Broken Wheel Pieces.
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

[QuestScript(60424)]
public class Quest60424Script : QuestScript
{
	protected override void Load()
	{
		SetId(60424);
		SetName("Despair and Echoes");
		SetDescription("Collect Broken Wheel Pieces");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE98_MQ_3"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23028));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("CASTLE98_MQ_4_NPC");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Move to the next region and use the Time Meter Necklace,{nl}then find the Broken Wheel Pieces.");
	}
}

