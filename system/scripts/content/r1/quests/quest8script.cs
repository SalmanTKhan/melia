//--- Melia Script -----------------------------------------------------------
// Guild Foundation
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(8)]
public class Quest8Script : QuestScript
{
	protected override void Load()
	{
		SetId(8);
		SetName("Guild Foundation");

		AddPrerequisite(new LevelPrerequisite(250));

		AddReward(new ItemReward("Ability_Point_Stone", 8));
		AddReward(new ItemReward("Adventure_Reward_Seed_14d_Team", 1));
		AddReward(new ItemReward("Event_Goddess_Statue_Team", 1));
	}
}

