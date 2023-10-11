//--- Melia Script -----------------------------------------------------------
// Interference of Necroventer
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Sculpture of Forecasts.
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

[QuestScript(7080)]
public class Quest7080Script : QuestScript
{
	protected override void Load()
	{
		SetId(7080);
		SetName("Interference of Necroventer");
		SetDescription("Talk to the Owl Sculpture of Forecasts");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRE_KATYN18_MQ_16_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_29"));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter_Q2));

		AddDialogHook("KATYN18_MAIN_OWL_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MAIN_OWL_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_BOSS_KILL_select1", "KATYN18_BOSS_KILL", "Defeat Necroventer", "Cancel"))
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

		await dialog.Msg("KATYN18_BOSS_KILL_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

