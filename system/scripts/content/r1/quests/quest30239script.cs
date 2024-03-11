//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (9)
//--- Description -----------------------------------------------------------
// Quest to Find the clue in the Barrack.
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

[QuestScript(30239)]
public class Quest30239Script : QuestScript
{
	protected override void Load()
	{
		SetId(30239);
		SetName("Inspect Inner Wall District 9 (9)");
		SetDescription("Find the clue in the Barrack");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_8"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Go to the Barrack for clues");
	}
}

