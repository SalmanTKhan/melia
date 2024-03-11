//--- Melia Script -----------------------------------------------------------
// Proving Skills [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Look for the Hoplite Submaster .
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

[QuestScript(8724)]
public class Quest8724Script : QuestScript
{
	protected override void Load()
	{
		SetId(8724);
		SetName("Proving Skills [Hoplite Advancement]");
		SetDescription("Look for the Hoplite Submaster ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(1, MonsterId.Boss_ShadowGaoler_J1));

		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HOPLITE4_1_01", "JOB_HOPLITE4_1", "I will try", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HOPLITE4_1_AG");
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

		await dialog.Msg("JOB_HOPLITE4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

