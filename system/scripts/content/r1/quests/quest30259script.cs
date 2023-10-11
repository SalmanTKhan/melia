//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(4)
//--- Description -----------------------------------------------------------
// Quest to Retrieve the keepsakes of Vincentas' Squad.
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

[QuestScript(30259)]
public class Quest30259Script : QuestScript
{
	protected override void Load()
	{
		SetId(30259);
		SetName("Assassin Ebonypawn(4)");
		SetDescription("Retrieve the keepsakes of Vincentas' Squad");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_5"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "On the road to closed town, you can see the keepsakes of the fallen comrades of Vincentas.{nl}Collect them and deliver them to him.");
	}
}

