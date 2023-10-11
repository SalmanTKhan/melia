//--- Melia Script -----------------------------------------------------------
// Assassin Ebonypawn(5)
//--- Description -----------------------------------------------------------
// Quest to Find Ebonypawn in the Barrack.
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

[QuestScript(30260)]
public class Quest30260Script : QuestScript
{
	protected override void Load()
	{
		SetId(30260);
		SetName("Assassin Ebonypawn(5)");
		SetDescription("Find Ebonypawn in the Barrack");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_4_SQ_7_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_6"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Go to the Barrack and find Ebonypawn.");
	}
}

