//--- Melia Script -----------------------------------------------------------
// The Eye of Demon Lord (1)
//--- Description -----------------------------------------------------------
// Quest to Contact with Linker Master.
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

[QuestScript(90175)]
public class Quest90175Script : QuestScript
{
	protected override void Load()
	{
		SetId(90175);
		SetName("The Eye of Demon Lord (1)");
		SetDescription("Contact with Linker Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LOWLV_EYEOFBAIGA_SQ_60_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_50"));

		AddObjective("kill0", "Kill 1 Gazing Golem", new KillObjective(1, MonsterId.Boss_GazingGolem_Q1));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("misc_ore17", 3));
		AddReward(new ItemReward("Vis", 12180));
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("LOWLV_EYEOFBAIGA_SQ_60_ST");
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("LOWLV_EYEOFBAIGA_SQ_70");
	}
}

