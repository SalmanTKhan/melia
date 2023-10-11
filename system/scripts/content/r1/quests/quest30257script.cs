//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(2)
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

[QuestScript(30257)]
public class Quest30257Script : QuestScript
{
	protected override void Load()
	{
		SetId(30257);
		SetName("Assassin Ebonypawn(2)");
		SetDescription("Search the Supplies Camp for Ebonypawn");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_3"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "At Supplies Camp, there are traps set by Ebonypawn.{nl}Throw a piece of obstacle to deactivate traps.");
	}
}

