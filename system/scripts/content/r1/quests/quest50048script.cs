//--- Melia Script -----------------------------------------------------------
// Sentry Bailey
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

[QuestScript(50048)]
public class Quest50048Script : QuestScript
{
	protected override void Load()
	{
		SetId(50048);
		SetName("Sentry Bailey");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new CompletedPrerequisite("FLASH64_MQ_03"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));

		AddDialogHook("AMANDA_65_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_65_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_65_MQ010_startnpc01", "UNDERFORTRESS_65_MQ010", "Look around with Monocle", "Ignore"))
		{
			case 1:
				// Func/AMANDA_LOOK_AROUND;
				await dialog.Msg("UNDERFORTRESS_65_MQ010_startnpc02");
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

		await dialog.Msg("UNDERFORTRESS_65_MQ010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

