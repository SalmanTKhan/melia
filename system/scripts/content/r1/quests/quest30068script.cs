//--- Melia Script -----------------------------------------------------------
// Soul Starvation (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Soul Starvation with the Namott of Suppression.
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

[QuestScript(30068)]
public class Quest30068Script : QuestScript
{
	protected override void Load()
	{
		SetId(30068);
		SetName("Soul Starvation (2)");
		SetDescription("Destroy the Soul Starvation with the Namott of Suppression");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_12_MQ_09_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_08"));

		AddObjective("kill0", "Kill 1 Merge", new KillObjective(1, MonsterId.Boss_Merge_Q2));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_OBJ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

