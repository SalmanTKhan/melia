//--- Melia Script -----------------------------------------------------------
// Preparations for the Crisis [Sapper Advancement]
//--- Description -----------------------------------------------------------
// Quest to Find the Sapper Master.
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

[QuestScript(8715)]
public class Quest8715Script : QuestScript
{
	protected override void Load()
	{
		SetId(8715);
		SetName("Preparations for the Crisis [Sapper Advancement]");
		SetDescription("Find the Sapper Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CATAPHRACT4_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_J1));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SAPPER4_1_01", "JOB_SAPPER4_1", "I will defeat it", "Decline"))
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

		await dialog.Msg("JOB_SAPPER4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

