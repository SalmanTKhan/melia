//--- Melia Script -----------------------------------------------------------
// Eternal Worship [Krivis Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Meet the Priest Master.
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

[QuestScript(17350)]
public class Quest17350Script : QuestScript
{
	protected override void Load()
	{
		SetId(17350);
		SetName("Eternal Worship [Krivis Advancement] (2)");
		SetDescription("Meet the Priest Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_KRIVI4_2_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_KRIVI4_1"));

		AddObjective("kill0", "Kill 1 Rocktortuga", new KillObjective(1, MonsterId.Boss_Rocktortuga_J1));

		AddReward(new ItemReward("JOB_KRIVI4_1_ITEM", 1));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KRIVI4_2_ST", "JOB_KRIVI4_2", "I will defeat the monsters", "Decline"))
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

		await dialog.Msg("JOB_KRIVI4_2_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

