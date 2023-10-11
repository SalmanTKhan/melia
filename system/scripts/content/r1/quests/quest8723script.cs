//--- Melia Script -----------------------------------------------------------
// A Gust [Rogue Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Rogue Master.
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

[QuestScript(8723)]
public class Quest8723Script : QuestScript
{
	protected override void Load()
	{
		SetId(8723);
		SetName("A Gust [Rogue Advancement]");
		SetDescription("Go to the Rogue Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_ROGUE4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("MASTER_ROGUE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ROGUE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ROGUE4_1_01", "JOB_ROGUE4_1", "I'll accept the test", "Decline"))
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

		await dialog.Msg("JOB_ROGUE4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

