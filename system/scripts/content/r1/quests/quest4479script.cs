//--- Melia Script -----------------------------------------------------------
// Activate the Passage Purifier (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Mine Compass.
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

[QuestScript(4479)]
public class Quest4479Script : QuestScript
{
	protected override void Load()
	{
		SetId(4479);
		SetName("Activate the Passage Purifier (2)");
		SetDescription("Use the Mine Compass");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MINE_1_CRYSTAL_18_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(17));
		AddPrerequisite(new CompletedPrerequisite("MINE_1_CRYSTAL_13"));

		AddObjective("collect0", "Collect 1 Passage Purifier Parts", new CollectItemObjective("MINE_1_CRYSTAL_18_ITEM", 1));
		AddDrop("MINE_1_CRYSTAL_18_ITEM", 10f, "boss_Spector_m");

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 221));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Mine Compass is pointing at District 6{nl}Go to District 6 and look for the part");
		var dialog = new Dialog(character, null);
		dialog.HideNPC("MINE_1_ELEVATOR");
	}
}

