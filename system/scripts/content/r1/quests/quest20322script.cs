//--- Melia Script -----------------------------------------------------------
// True Origin of the Curse (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Roana.
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

[QuestScript(20322)]
public class Quest20322Script : QuestScript
{
	protected override void Load()
	{
		SetId(20322);
		SetName("True Origin of the Curse (2)");
		SetDescription("Talk to Priest Roana");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIMROAD55_SQ05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(144));
		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ07"));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(1, MonsterId.Boss_Chapparition_Q3));

		AddReward(new ExpReward(1279350, 1279350));
		AddReward(new ItemReward("PRIST_REPORT02", 1));
		AddReward(new ItemReward("expCard8", 5));
		AddReward(new ItemReward("Vis", 3744));

		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIMROAD55_SQ05_select01", "PILGRIMROAD55_SQ05", "I'm ready", "I'm not ready yet"))
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

		await dialog.Msg("PILGRIMROAD55_SQ05_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

