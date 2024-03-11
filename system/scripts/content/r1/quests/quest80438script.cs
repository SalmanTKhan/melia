//--- Melia Script -----------------------------------------------------------
// The Beholder's Conciliation
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(80438)]
public class Quest80438Script : QuestScript
{
	protected override void Load()
	{
		SetId(80438);
		SetName("The Beholder's Conciliation");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Possible, QuestStatus.Possible, "CHATHEDRAL54_BLACKMAN_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(141));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ01_PART1"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));

		AddDialogHook("CHATHEDRAL54_BLACKMAN", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_BLACKMAN", "BeforeEnd", BeforeEnd);
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

		dialog.HideNPC("CHATHEDRAL54_BLACKMAN");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

