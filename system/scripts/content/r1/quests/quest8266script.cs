//--- Melia Script -----------------------------------------------------------
// Disaster of Saknis Plains (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Officer Philipas.
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

[QuestScript(8266)]
public class Quest8266Script : QuestScript
{
	protected override void Load()
	{
		SetId(8266);
		SetName("Disaster of Saknis Plains (2)");
		SetDescription("Talk to Senior Officer Philipas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN14_MQ_BOSS_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_24"));

		AddObjective("kill0", "Kill 1 Mushwort", new KillObjective(1, MonsterId.Boss_Mushwort_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_VACENIN_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_VACENIN_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_25_01", "KATYN14_MQ_25", "I will join the battle", "Give me some time to prepare"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN14_MQ_25_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

