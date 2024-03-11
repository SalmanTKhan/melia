//--- Melia Script -----------------------------------------------------------
// Materials for Medicine [Cleric Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Cleric Master.
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

[QuestScript(8742)]
public class Quest8742Script : QuestScript
{
	protected override void Load()
	{
		SetId(8742);
		SetName("Materials for Medicine [Cleric Advancement]");
		SetDescription("Go to the Cleric Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CLERIC5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Mothstem", new KillObjective(1, MonsterId.Boss_Mothstem_J1));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CLERIC5_1_01", "JOB_CLERIC5_1", "What should I do?", "I need more time to think"))
		{
			case 1:
				await dialog.Msg("JOB_CLERIC5_1_AG");
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

		await dialog.Msg("JOB_CLERIC5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

