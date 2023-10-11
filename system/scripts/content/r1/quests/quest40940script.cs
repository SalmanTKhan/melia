//--- Melia Script -----------------------------------------------------------
// And, Eternal Repose (3)
//--- Description -----------------------------------------------------------
// Quest to Return to Demon Svitrigaila.
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

[QuestScript(40940)]
public class Quest40940Script : QuestScript
{
	protected override void Load()
	{
		SetId(40940);
		SetName("And, Eternal Repose (3)");
		SetDescription("Return to Demon Svitrigaila");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH_58_SQ_090_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_080"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_090_ST", "FLASH_58_SQ_090", "Say Farewell", "Cancel"))
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "It seems that what Svitrigaila wanted has been fulfilled");
		dialog.HideNPC("FLASH_58_SVTRIGAILA");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

