//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Linker [Linker Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Linker Master.
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

[QuestScript(19170)]
public class Quest19170Script : QuestScript
{
	protected override void Load()
	{
		SetId(19170);
		SetName("Complete the Mission of a Linker [Linker Advancement]");
		SetDescription("Meet the Linker Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SPYLIAL5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(1, MonsterId.Boss_Werewolf_J1));

		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_LINKER5_1_ST", "JOB_LINKER5_1", "I will defeat the Werewolf", "Decline"))
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

		await dialog.Msg("JOB_LINKER5_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

