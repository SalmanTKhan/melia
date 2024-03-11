//--- Melia Script -----------------------------------------------------------
// Guardian Destructors (2)
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

[QuestScript(8386)]
public class Quest8386Script : QuestScript
{
	protected override void Load()
	{
		SetId(8386);
		SetName("Guardian Destructors (2)");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA4F_MQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(92));
		AddPrerequisite(new CompletedPrerequisite("ZACHA4F_MQ_01"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ZACHA4F_MQ_04_BLACKMAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_MQ_04_select01", "ZACHA4F_MQ_04", "Say that you will stop the Guardians right away", "Ignore"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("ZACHA4F_MQ_04_BLACKMAN");
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

		await dialog.Msg("CameraShockWaveLocal/2/99999/15/5/30/0");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "It seems that the Royal Mausoleum will collapse soon!{nl}Stop the Guardians attacking it!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

