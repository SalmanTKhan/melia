//--- Melia Script -----------------------------------------------------------
// Resolve the Tussle (2)
//--- Description -----------------------------------------------------------
// Quest to Help the soldiers in battle at the Kalbos Vacant Lot and guide them to the base.
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

[QuestScript(91096)]
public class Quest91096Script : QuestScript
{
	protected override void Load()
	{
		SetId(91096);
		SetName("Resolve the Tussle (2)");
		SetDescription("Help the soldiers in battle at the Kalbos Vacant Lot and guide them to the base");

		AddPrerequisite(new LevelPrerequisite(462));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_4"));

		AddObjective("kill0", "Kill 20 Blickferret Fighter(s) or Blickferret Swordsman(s) or Blickferret Shielder(s)", new KillObjective(20, 59695, 59696, 59697));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_1_FCASTLE2_MQ_6");
	}
}

