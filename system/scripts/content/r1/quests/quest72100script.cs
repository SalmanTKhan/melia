//--- Melia Script -----------------------------------------------------------
// Trading with Hostage at Stake
//--- Description -----------------------------------------------------------
// Quest to Talk to Skirgaila.
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

[QuestScript(72100)]
public class Quest72100Script : QuestScript
{
	protected override void Load()
	{
		SetId(72100);
		SetName("Trading with Hostage at Stake");
		SetDescription("Talk to Skirgaila");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE261_SQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(333));

		AddDialogHook("3CMLAKE_SKIRGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ01_DLG01", "F_3CMLAKE261_SQ01", "I will search for it", "I can't. I have other missions to take care of."))
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

		await dialog.Msg("3CMLAKE261_SQ01_DLG03");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "[Trading with Hostage at Stake]{nl}Clear!");
		dialog.HideNPC("3CMLAKE261_SQ01_TRACK_TRIG");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

