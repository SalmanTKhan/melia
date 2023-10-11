//--- Melia Script -----------------------------------------------------------
// Practice with an Actual Fight [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Swordsman Master.
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

[QuestScript(17700)]
public class Quest17700Script : QuestScript
{
	protected override void Load()
	{
		SetId(17700);
		SetName("Practice with an Actual Fight [Swordsman Advancement]");
		SetDescription("Talk to the Swordsman Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SWORDMAN5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Honeypin", new KillObjective(1, MonsterId.Boss_Honeypin_J1));

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SWORDMAN5_1_select", "JOB_SWORDMAN5_1", "I will defeat the Honeypin", "Decline"))
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

		await dialog.Msg("JOB_SWORDMAN5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

