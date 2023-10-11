//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(1)
//--- Description -----------------------------------------------------------
// Quest to Search the Supplies Camp for Ebonypawn.
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

[QuestScript(30256)]
public class Quest30256Script : QuestScript
{
	protected override void Load()
	{
		SetId(30256);
		SetName("Assassin Ebonypawn(1)");
		SetDescription("Search the Supplies Camp for Ebonypawn");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_2"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("CASTLE_20_4_SQ_3_ITEM", 1));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));
	}

	public override void OnStart(Character character, Quest quest)
	{
		//await Task.Delay(1000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Ebonypawn set up traps in the armory.{nl}Find Ebonypawn at Supplies Camp.");
	}
}

