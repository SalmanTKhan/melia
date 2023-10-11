//--- Melia Script -----------------------------------------------------------
// The Power to Lead Others [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(70340)]
public class Quest70340Script : QuestScript
{
	protected override void Load()
	{
		SetId(70340);
		SetName("The Power to Lead Others [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia_J1));

		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_RODELERO6_1_1", "JOB_2_RODELERO6", "I will try", "I don't think that's necessary"))
		{
			case 1:
				await dialog.Msg("JOB_2_RODELERO6_1_2");
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


		return HookResult.Break;
	}
}

