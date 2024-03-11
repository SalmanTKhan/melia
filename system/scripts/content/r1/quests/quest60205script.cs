//--- Melia Script -----------------------------------------------------------
// Back in time(6)
//--- Description -----------------------------------------------------------
// Quest to Deal with the monsters in the surrounding area.
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

[QuestScript(60205)]
public class Quest60205Script : QuestScript
{
	protected override void Load()
	{
		SetId(60205);
		SetName("Back in time(6)");
		SetDescription("Deal with the monsters in the surrounding area");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_MQ_3"));

		AddObjective("kill0", "Kill 15 Red Slime(s) or Yellow Arma(s) or Yellow Pyran(s) or Red Wizard Shaman Doll(s)", new KillObjective(15, 58508, 58509, 58510, 58511));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14168));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FIRETOWER691_MQ_5");
	}
}

