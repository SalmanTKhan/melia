//--- Melia Script -----------------------------------------------------------
// What Must Be Done (5)
//--- Description -----------------------------------------------------------
// Quest to Remove the Demon Summoning Crystal by using the Worn Gravity Stone.
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

[QuestScript(30192)]
public class Quest30192Script : QuestScript
{
	protected override void Load()
	{
		SetId(30192);
		SetName("What Must Be Done (5)");
		SetDescription("Remove the Demon Summoning Crystal by using the Worn Gravity Stone");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_8"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Use the Worn Gravity Stone to remove the Demon Summoning Crystal", 5);
	}
}

