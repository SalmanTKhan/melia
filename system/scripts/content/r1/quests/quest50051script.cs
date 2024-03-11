//--- Melia Script -----------------------------------------------------------
// Drawing Attention (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(50051)]
public class Quest50051Script : QuestScript
{
	protected override void Load()
	{
		SetId(50051);
		SetName("Drawing Attention (3)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_65_MQ030"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("AMANDA_65_2", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_65_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_65_MQ040_start01", "UNDERFORTRESS_65_MQ040", "I will come back after setting it", "I'll wait a little bit"))
		{
			case 1:
				await dialog.Msg("UNDER_65_MQ040_start02");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("UNDERFORTRESS_65_MQ040_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

