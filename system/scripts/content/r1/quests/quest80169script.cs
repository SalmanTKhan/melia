//--- Melia Script -----------------------------------------------------------
// Powerful Being (2)
//--- Description -----------------------------------------------------------
// Quest to Examine Demon Queen Gesti.
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

[QuestScript(80169)]
public class Quest80169Script : QuestScript
{
	protected override void Load()
	{
		SetId(80169);
		SetName("Powerful Being (2)");
		SetDescription("Examine Demon Queen Gesti");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_5_MQ_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_7"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("LIMESTONE_52_5_GESTI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_5_DALIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("LIMESTONE_52_5_MQ_8_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

