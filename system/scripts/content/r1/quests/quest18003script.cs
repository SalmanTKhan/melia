//--- Melia Script -----------------------------------------------------------
// Drugys Courtyard's Binding Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Check the binding magic circle in Drugys Courtyard..
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

[QuestScript(18003)]
public class Quest18003Script : QuestScript
{
	protected override void Load()
	{
		SetId(18003);
		SetName("Drugys Courtyard's Binding Magic Circle");
		SetDescription("Check the binding magic circle in Drugys Courtyard.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_4_MQ03_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ01"));

		AddObjective("kill0", "Kill 1 Mothstem", new KillObjective(1, MonsterId.Boss_Mothstem));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ03_NPC01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

