//--- Melia Script -----------------------------------------------------------
// Reduce the Source of Pain [Sadhu Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sadhu Master.
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

[QuestScript(70342)]
public class Quest70342Script : QuestScript
{
	protected override void Load()
	{
		SetId(70342);
		SetName("Reduce the Source of Pain [Sadhu Advancement]");
		SetDescription("Talk to the Sadhu Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(1, MonsterId.Boss_Colimencia_J1));

		AddDialogHook("JOB_2_SADHU_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SADHU_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SADHU6_1_1", "JOB_2_SADHU6", "Ask what to do", "Tell him it won't be helpful"))
		{
			case 1:
				await dialog.Msg("JOB_2_SADHU6_1_2");
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

