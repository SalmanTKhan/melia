//--- Melia Script -----------------------------------------------------------
// Search Scouts under Attack
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Dainus.
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

[QuestScript(4390)]
public class Quest4390Script : QuestScript
{
	protected override void Load()
	{
		SetId(4390);
		SetName("Search Scouts under Attack");
		SetDescription("Talk to Soldier Dainus");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN22_BOSSKILL_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(122));

		AddObjective("kill0", "Kill 1 Ironbaum", new KillObjective(1, MonsterId.Boss_Ironbaum));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3050));

		AddDialogHook("THORN22_BOSSKILL_1_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_BOSSKILL_1_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_BOSSKILL_1_select01", "THORN22_BOSSKILL_1", "I'll go to Drieza Waterland", "Let's get out of here together"))
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

		await dialog.Msg("THORN22_BOSSKILL_1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

