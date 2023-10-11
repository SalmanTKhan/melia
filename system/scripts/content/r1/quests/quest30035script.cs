//--- Melia Script -----------------------------------------------------------
// Missing Delegation's Whereabouts [Doppelsoeldner Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Doppelsoeldner Master.
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

[QuestScript(30035)]
public class Quest30035Script : QuestScript
{
	protected override void Load()
	{
		SetId(30035);
		SetName("Missing Delegation's Whereabouts [Doppelsoeldner Advancement]");
		SetDescription("Talk to the Doppelsoeldner Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_DOPPELSOELDNER_6_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(1, MonsterId.Boss_Werewolf_J2));

		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DOPPELSOELDNER_6_1_select", "JOB_DOPPELSOELDNER_6_1", "Tell to believe in you", "I don't want to get involved in a suspicious task"))
		{
			case 1:
				await dialog.Msg("JOB_DOPPELSOELDNER_6_1_agree");
				dialog.UnHideNPC("JOB_DOPPELSOELDNER_6_1_OBJ01");
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

		await dialog.Msg("JOB_DOPPELSOELDNER_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

