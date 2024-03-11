//--- Melia Script -----------------------------------------------------------
// Proving Faith [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Paladin Master.
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

[QuestScript(8748)]
public class Quest8748Script : QuestScript
{
	protected override void Load()
	{
		SetId(8748);
		SetName("Proving Faith [Paladin Advancement]");
		SetDescription("Talk to the Paladin Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PELTASTA5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(1, MonsterId.Boss_Gaigalas_J1));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PALADIN5_1_01", "JOB_PALADIN5_1", "I can do anything", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_PALADIN5_1_04");
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

		await dialog.Msg("JOB_PALADIN5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

