//--- Melia Script -----------------------------------------------------------
// Echoes and Tragedy
//--- Description -----------------------------------------------------------
// Quest to Broken Arrow.
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

[QuestScript(60426)]
public class Quest60426Script : QuestScript
{
	protected override void Load()
	{
		SetId(60426);
		SetName("Echoes and Tragedy");
		SetDescription("Broken Arrow");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE98_MQ_5"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23028));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "More to the next region and use the Time Meter Necklace{nl}on the monsters, then find the Broken Arrow.");
	}
}

