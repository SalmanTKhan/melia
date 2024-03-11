//--- Melia Script -----------------------------------------------------------
// The Rituals of an Exorcist
//--- Description -----------------------------------------------------------
// Quest to Talk to the Exorcist Master.
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

[QuestScript(50372)]
public class Quest50372Script : QuestScript
{
	protected override void Load()
	{
		SetId(50372);
		SetName("The Rituals of an Exorcist");
		SetDescription("Talk to the Exorcist Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_EXORCIST1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("EXORCIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("EXORCIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_EXORCIST1_start1", "JOB_EXORCIST1", "I'll perform the exorcism.", "I won't do it."))
		{
			case 1:
				dialog.UnHideNPC("EXORCIST_PLACE_HIDE");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Set the Prayer Book to the quick slot before interacting with the Binding Orb to perform the exorcism.");
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

		await dialog.Msg("JOB_EXORCIST1_succ1");
		dialog.HideNPC("EXORCIST_PLACE_HIDE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

