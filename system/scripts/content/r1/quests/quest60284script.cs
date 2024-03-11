//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (4)
//--- Description -----------------------------------------------------------
// Quest to Defeat the Demons in Pagal Market.
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

[QuestScript(60284)]
public class Quest60284Script : QuestScript
{
	protected override void Load()
	{
		SetId(60284);
		SetName("The Vulnerable Fugitive (4)");
		SetDescription("Defeat the Demons in Pagal Market");

		AddPrerequisite(new LevelPrerequisite(371));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_3"));

		AddObjective("kill0", "Kill 13 Bishop Star(s)", new KillObjective(13, MonsterId.Bishopstar));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20000));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("DCAPITAL105_SQ_5");
	}
}

