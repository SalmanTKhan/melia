//--- Melia Script -----------------------------------------------------------
// Fedimian Completionist [Archer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(1122)]
public class Quest1122Script : QuestScript
{
	protected override void Load()
	{
		SetId(1122);
		SetName("Fedimian Completionist [Archer Advancement] (2)");
		SetDescription("Talk to the Rodelero Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARREL3_2_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_ARCHER3_1"));

		AddObjective("kill0", "Kill 1 Minotaur", new KillObjective(1, MonsterId.Boss_Minotaurs_J1));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ARCHER3_2_select1", "JOB_ARCHER3_2", "I will defeat it", "It sounds too dangerous"))
		{
			case 1:
				await dialog.Msg("JOB_ARCHER3_2_prog1");
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

		await dialog.Msg("JOB_ARCHER3_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

