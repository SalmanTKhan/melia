//--- Melia Script -----------------------------------------------------------
// Invasion of the Vubbes
//--- Description -----------------------------------------------------------
// Quest to Talk to the Miners' Village Mayor.
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

[QuestScript(8079)]
public class Quest8079Script : QuestScript
{
	protected override void Load()
	{
		SetId(8079);
		SetName("Invasion of the Vubbes");
		SetDescription("Talk to the Miners' Village Mayor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SOUT_Q_13_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(11));

		AddObjective("kill0", "Kill 8 Vubbe Thief(s) or Vubbe Archer(s)", new KillObjective(8, 11120, 57266));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 143));

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_13_ST", "SOUT_Q_13", "I'll go to the Vubbe's base and defeat them", "Disregard"))
		{
			case 1:
				await dialog.Msg("SOUT_Q_13_AC");
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

		await dialog.Msg("SOUT_Q_13_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

