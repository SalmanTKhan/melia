//--- Melia Script -----------------------------------------------------------
// Confidence
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

[QuestScript(50079)]
public class Quest50079Script : QuestScript
{
	protected override void Load()
	{
		SetId(50079);
		SetName("Confidence");
		SetDescription("Talk to Grave Robber Amanda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_69_MQ010_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(214));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_68_MQ070"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("UNDER69_MQ1_ITEM01", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("AMANDA_69_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_69_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_69_MQ010_startnpc01", "UNDERFORTRESS_69_MQ010", "Alright", "Let's go a bit later"))
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

		await dialog.Msg("UNDER_69_MQ010_succ01");
		await dialog.Msg("UNDER_69_MQ010_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

