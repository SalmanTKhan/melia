//--- Melia Script -----------------------------------------------------------
// Drawing Attention (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50052)]
public class Quest50052Script : QuestScript
{
	protected override void Load()
	{
		SetId(50052);
		SetName("Drawing Attention (4)");
		SetDescription("Talk to Grave Robber Amanda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_65_MQ050_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_65_MQ040"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 42000));

		AddDialogHook("AMANDA_65_2", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_65_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_65_MQ050_startnpc01", "UNDERFORTRESS_65_MQ050", "Wait with your ears covered", "I have something to do"))
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

		await dialog.Msg("UNDERFORTRESS_65_MQ050_succ01");
		dialog.UnHideNPC("AMANDA_66_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

