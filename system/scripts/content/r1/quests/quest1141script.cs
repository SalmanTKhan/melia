//--- Melia Script -----------------------------------------------------------
// Training of Great Nature [Druid Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Druid Master.
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

[QuestScript(1141)]
public class Quest1141Script : QuestScript
{
	protected override void Load()
	{
		SetId(1141);
		SetName("Training of Great Nature [Druid Advancement]");
		SetDescription("Talk to the Druid Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_DRUID5_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Druid Master", new KillObjective(1, MonsterId.Npc_DRU_Master));

		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DRUID3_1_select1", "JOB_DRUID5_1", "I will take on the duel", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_DRUID3_1_agree1");
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

		await dialog.Msg("JOB_DRUID3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

