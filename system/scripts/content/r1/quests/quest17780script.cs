//--- Melia Script -----------------------------------------------------------
// Ground Combat Training [Corsair Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Corsair Master.
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

[QuestScript(17780)]
public class Quest17780Script : QuestScript
{
	protected override void Load()
	{
		SetId(17780);
		SetName("Ground Combat Training [Corsair Advancement]");
		SetDescription("Talk to the Corsair Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SWORDMAN5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Honeypin", new KillObjective(1, MonsterId.Boss_Honeypin_J1));

		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CORSAIR4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CORSAIR5_1_select", "JOB_CORSAIR5_1", "I will defeat the Honeypin", "Decline"))
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

		await dialog.Msg("JOB_CORSAIR5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

