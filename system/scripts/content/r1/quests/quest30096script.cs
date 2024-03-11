//--- Melia Script -----------------------------------------------------------
// Ranger On-Site Training [ Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Submaster.
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

[QuestScript(30096)]
public class Quest30096Script : QuestScript
{
	protected override void Load()
	{
		SetId(30096);
		SetName("Ranger On-Site Training [ Ranger Advancement]");
		SetDescription("Talk to the Ranger Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_2_RANGER_4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(1, MonsterId.Boss_Necrovanter_J1));

		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_RANGER_4_1_select", "JOB_2_RANGER_4_1", "I will show you my skills", "If it can't be helped, then it can't be helped"))
		{
			case 1:
				await dialog.Msg("JOB_2_RANGER_4_1_agree");
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

		await dialog.Msg("JOB_2_RANGER_4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

