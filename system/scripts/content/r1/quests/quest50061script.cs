//--- Melia Script -----------------------------------------------------------
// Hidden Area
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ruklys Army Officer's Spirit.
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

[QuestScript(50061)]
public class Quest50061Script : QuestScript
{
	protected override void Load()
	{
		SetId(50061);
		SetName("Hidden Area");
		SetDescription("Talk to the Ruklys Army Officer's Spirit");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_66_MQ070_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ060"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));

		AddDialogHook("UNDER66_MQ07_GHOST", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_65_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_MQ070_startnpc01", "UNDERFORTRESS_66_MQ070", "I don't know what you are saying", "Ignore"))
		{
			case 1:
				await dialog.Msg("UNDER_66_MQ070_startnpc02");
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

		await dialog.Msg("UNDERFORTRESS_66_MQ070_succ01");
		dialog.UnHideNPC("AMANDA_67_1");
		dialog.HideNPC("AMANDA_66_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

