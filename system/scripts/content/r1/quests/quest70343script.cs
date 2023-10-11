//--- Melia Script -----------------------------------------------------------
// Honorable Power [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Paladin Submaster.
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

[QuestScript(70343)]
public class Quest70343Script : QuestScript
{
	protected override void Load()
	{
		SetId(70343);
		SetName("Honorable Power [Paladin Advancement]");
		SetDescription("Paladin Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PELTASTA5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(1, MonsterId.Boss_Gaigalas_J1));

		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PALADIN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PALADIN6_1_1", "JOB_2_PALADIN6", "Ask how to prove it", "I don't want to prove it"))
		{
			case 1:
				await dialog.Msg("JOB_2_PALADIN6_1_2");
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


		return HookResult.Break;
	}
}

