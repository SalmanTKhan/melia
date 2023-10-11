//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 2 [Quarrel Shooter Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Master.
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

[QuestScript(1089)]
public class Quest1089Script : QuestScript
{
	protected override void Load()
	{
		SetId(1089);
		SetName("Dream Book of the Bow 2 [Quarrel Shooter Advancement] (3)");
		SetDescription("Talk to the Quarrel Shooter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HUNTER2_3_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_QUARREL2_2"));

		AddReward(new ItemReward("Book5", 1));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_QUARREL2_3_select1", "JOB_QUARREL2_3", "I'll go to the Archer Master", "I'll quit here"))
		{
			case 1:
				await dialog.Msg("JOB_QUARREL2_3_agree1");
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

		ZoneServer.Instance.World.FindNPC("MASTER_ARCHER")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Recuperate_circle", 1.5f, "BOT");
		await dialog.Msg("JOB_QUARREL2_3_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

