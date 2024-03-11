//--- Melia Script -----------------------------------------------------------
// Corrupted Lantern (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8440)]
public class Quest8440Script : QuestScript
{
	protected override void Load()
	{
		SetId(8440);
		SetName("Corrupted Lantern (2)");
		SetDescription("Talk to the Guardian Stone Statue");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA3F_SQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(88));
		AddPrerequisite(new CompletedPrerequisite("ZACHA3F_SQ_02"));

		AddObjective("kill0", "Kill 1 Royal Mausoleum Stone Lantern", new KillObjective(1, MonsterId.Npc_Zachariel_Lantern));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1760));
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "This wasn't the only stone lantern{nl}Find the other corrupted stone lanterns and destroy them");
	}
}

