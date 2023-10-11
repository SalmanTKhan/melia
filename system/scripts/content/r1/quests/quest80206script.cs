//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Goda.
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

[QuestScript(80206)]
public class Quest80206Script : QuestScript
{
	protected override void Load()
	{
		SetId(80206);
		SetName("Good Use For a Wand (6)");
		SetDescription("Talk to Priest Goda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL56_SQ05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(145));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_SQ07"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_SQ03", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_SQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_SQ05_select01", "CHATHEDRAL56_SQ05", "I'll complete the magic circle.", "You can complete the circle yourself."))
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

		await dialog.Msg("CHATHEDRAL56_SQ05_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

