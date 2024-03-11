//--- Melia Script -----------------------------------------------------------
// Tragedy and Echoes
//--- Description -----------------------------------------------------------
// Quest to Collect Broken Statue Pieces.
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

[QuestScript(60423)]
public class Quest60423Script : QuestScript
{
	protected override void Load()
	{
		SetId(60423);
		SetName("Tragedy and Echoes");
		SetDescription("Collect Broken Statue Pieces");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE98_MQ_2"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23028));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("CASTLE98_MQ_3_NPC");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Move to the next region and use the Time Meter Necklace,{nl}then find the Broken Statue Pieces.");
	}
}

