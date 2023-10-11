//--- Melia Script -----------------------------------------------------------
// The Worrying Owl at Ishrai Crossroads
//--- Description -----------------------------------------------------------
// Quest to Observe the Fallen Owl Sculpture.
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

[QuestScript(20075)]
public class Quest20075Script : QuestScript
{
	protected override void Load()
	{
		SetId(20075);
		SetName("The Worrying Owl at Ishrai Crossroads");
		SetDescription("Observe the Fallen Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST5_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(112));

		AddObjective("kill0", "Kill 1 Green Woodspirit", new KillObjective(1, MonsterId.Boss_Woodspirit_Green));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_OWLJUNIOR3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

