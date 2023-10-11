//--- Melia Script -----------------------------------------------------------
// The One Who Goes Through Everything [Cataphract Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cataphract Master.
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

[QuestScript(70341)]
public class Quest70341Script : QuestScript
{
	protected override void Load()
	{
		SetId(70341);
		SetName("The One Who Goes Through Everything [Cataphract Advancement]");
		SetDescription("Talk to the Cataphract Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PELTASTA5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(1, MonsterId.Boss_Gaigalas_J1));

		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CATAPHRACT6_1_1", "JOB_2_CATAPHRACT6", "I will defeat the Gaigalas", "I don't think I can do such things"))
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


		return HookResult.Break;
	}
}

