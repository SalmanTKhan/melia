//--- Melia Script -----------------------------------------------------------
// Activities of a Pyromancer [Pyromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(17610)]
public class Quest17610Script : QuestScript
{
	protected override void Load()
	{
		SetId(17610);
		SetName("Activities of a Pyromancer [Pyromancer Advancement]");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PYROMANCER4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Poata", new KillObjective(1, MonsterId.Boss_Poata_J1));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PYROMANCER4_1_select", "JOB_PYROMANCER4_1", "I will defeat Poata", "Decline"))
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

		await dialog.Msg("JOB_PYROMANCER4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

