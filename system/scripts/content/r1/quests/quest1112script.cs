//--- Melia Script -----------------------------------------------------------
// Exorcism [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Priest Master.
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

[QuestScript(1112)]
public class Quest1112Script : QuestScript
{
	protected override void Load()
	{
		SetId(1112);
		SetName("Exorcism [Priest Advancement]");
		SetDescription("Talk to the Priest Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PRIEST2_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter_J1));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PRIEST2_1_select1", "JOB_PRIEST2_1", "I will perform the exorcism", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PRIEST2_1_agree1");
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

		await dialog.Msg("JOB_PRIEST2_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

