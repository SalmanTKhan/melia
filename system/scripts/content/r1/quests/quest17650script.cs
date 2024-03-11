//--- Melia Script -----------------------------------------------------------
// Activities of a Thaurmaturge [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Thaumaturge Master.
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

[QuestScript(17650)]
public class Quest17650Script : QuestScript
{
	protected override void Load()
	{
		SetId(17650);
		SetName("Activities of a Thaurmaturge [Thaumaturge Advancement]");
		SetDescription("Talk with the Thaumaturge Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_THAUMATURGE4_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Salamander", new KillObjective(1, MonsterId.Boss_Salamander_J1));

		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_THAUMATURGE4_1_select", "JOB_THAUMATURGE4_1", "I will get rid of Salamander", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_THAUMATURGE4_1_agree");
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

		await dialog.Msg("JOB_THAUMATURGE4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

