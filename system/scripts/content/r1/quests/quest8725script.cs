//--- Melia Script -----------------------------------------------------------
// Proving Qualification [Barbarian Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Barbarian Master.
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

[QuestScript(8725)]
public class Quest8725Script : QuestScript
{
	protected override void Load()
	{
		SetId(8725);
		SetName("Proving Qualification [Barbarian Advancement]");
		SetDescription("Meet the Barbarian Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BARBARIAN4_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Yekub", new KillObjective(1, MonsterId.Boss_Yekub_J2));

		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BARBARIAN4_1_01", "JOB_BARBARIAN4_1", "I will defeat Yekub first", "Decline"))
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

		await dialog.Msg("JOB_BARBARIAN4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

