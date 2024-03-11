//--- Melia Script -----------------------------------------------------------
// Outstanding Eyesight
//--- Description -----------------------------------------------------------
// Quest to Talk to Guard Horton.
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

[QuestScript(80224)]
public class Quest80224Script : QuestScript
{
	protected override void Load()
	{
		SetId(80224);
		SetName("Outstanding Eyesight");
		SetDescription("Talk to Guard Horton");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH63_SQ_13_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(193));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_SQ13", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_SQ13", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ13_select01", "FLASH63_SQ13", "I will check it", "I don't want to"))
		{
			case 1:
				await dialog.Msg("FLASH63_SQ13_agree01");
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

		await dialog.Msg("FLASH63_SQ13_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

