//--- Melia Script -----------------------------------------------------------
// Experience is an Asset [Highlander Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(17720)]
public class Quest17720Script : QuestScript
{
	protected override void Load()
	{
		SetId(17720);
		SetName("Experience is an Asset [Highlander Advancement]");
		SetDescription("Talk to the Highlander Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SWORDMAN5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Honeypin", new KillObjective(1, MonsterId.Boss_Honeypin_J1));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HIGHLANDER5_1_select", "JOB_HIGHLANDER5_1", "How do you gain good experiences?", "I disagree"))
		{
			case 1:
				await dialog.Msg("JOB_HIGHLANDER5_1_prog");
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

		await dialog.Msg("JOB_HIGHLANDER5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

