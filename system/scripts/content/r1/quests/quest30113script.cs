//--- Melia Script -----------------------------------------------------------
// The Battle Abilities of Scout [Scout Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout Submaster.
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

[QuestScript(30113)]
public class Quest30113Script : QuestScript
{
	protected override void Load()
	{
		SetId(30113);
		SetName("The Battle Abilities of Scout [Scout Advancement]");
		SetDescription("Talk to the Scout Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_SCOUT5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(1, MonsterId.Boss_Deadbone_J1));

		AddDialogHook("JOB_2_SCOUT_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SCOUT_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SCOUT_6_1_select", "JOB_2_SCOUT_6_1", "Tell me about the request", "That sounds dangerous; I'll pass"))
		{
			case 1:
				await dialog.Msg("JOB_2_SCOUT_6_1_agree");
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

		await dialog.Msg("JOB_2_SCOUT_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

