//--- Melia Script -----------------------------------------------------------
// Talk with the Bow [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Master.
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

[QuestScript(1144)]
public class Quest1144Script : QuestScript
{
	protected override void Load()
	{
		SetId(1144);
		SetName("Talk with the Bow [Hunter Advancement]");
		SetDescription("Talk to the Hunter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Hunter Master", new KillObjective(1, MonsterId.Npc_HUT_Master));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER3_1_select1", "JOB_HUNTER3_1", "Duel with the Master", "Avoid the duel"))
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

		await dialog.Msg("JOB_HUNTER3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

