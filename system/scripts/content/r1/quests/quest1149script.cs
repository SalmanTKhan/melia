//--- Melia Script -----------------------------------------------------------
// Test of the Blades [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Swordsman Master.
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

[QuestScript(1149)]
public class Quest1149Script : QuestScript
{
	protected override void Load()
	{
		SetId(1149);
		SetName("Test of the Blades [Swordsman Advancement]");
		SetDescription("Talk to the Swordsman Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARREL3_2_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Minotaur", new KillObjective(1, MonsterId.Boss_Minotaurs_J1));

		AddDialogHook("MASTER_SWORDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SWORDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WARRIOR3_1_select1", "JOB_WARRIOR3_1", "I will defeat the Minotaur", "Decline"))
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

		await dialog.Msg("JOB_WARRIOR3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

