//--- Melia Script -----------------------------------------------------------
// Monster Preying on Military Supplies (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Dennis.
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

[QuestScript(50018)]
public class Quest50018Script : QuestScript
{
	protected override void Load()
	{
		SetId(50018);
		SetName("Monster Preying on Military Supplies (2)");
		SetDescription("Talk to Soldier Dennis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_50_1_SQ_110_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(71));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_100"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1349));

		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_SOLDIER01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_110_select01", "SIAULIAI_50_1_SQ_110", "I will help Alan", "Time for farewell"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_110_AG");
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

		await dialog.Msg("SIAULIAI_50_1_SQ_110_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

