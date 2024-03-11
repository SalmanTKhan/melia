//--- Melia Script -----------------------------------------------------------
// Completing the Elementalist's Mission [Elementalist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet with the Elementalist Submaster. .
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

[QuestScript(19190)]
public class Quest19190Script : QuestScript
{
	protected override void Load()
	{
		SetId(19190);
		SetName("Completing the Elementalist's Mission [Elementalist Advancement]");
		SetDescription("Meet with the Elementalist Submaster. ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUELE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Netherbovine", new KillObjective(1, MonsterId.Boss_NetherBovine_J1));

		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARLOCK5_1_ST", "JOB_WARLOCK5_1", "Of course I'll do it", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_WARLOCK5_1_AC");
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

		await dialog.Msg("JOB_WARLOCK5_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

