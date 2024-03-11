//--- Melia Script -----------------------------------------------------------
// Treasure Hunting (4)
//--- Description -----------------------------------------------------------
// Quest to Check the area Rolandas Jonas told you.
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

[QuestScript(20173)]
public class Quest20173Script : QuestScript
{
	protected override void Load()
	{
		SetId(20173);
		SetName("Treasure Hunting (4)");
		SetDescription("Check the area Rolandas Jonas told you");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS27_MQ_4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_MQ_3"));

		AddObjective("kill0", "Kill 7 Sauga(s)", new KillObjective(7, MonsterId.Sauga_S));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1273));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS27_MQ_5");
	}
}

