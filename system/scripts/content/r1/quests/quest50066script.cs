//--- Melia Script -----------------------------------------------------------
// Fortress of the Land Manager
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50066)]
public class Quest50066Script : QuestScript
{
	protected override void Load()
	{
		SetId(50066);
		SetName("Fortress of the Land Manager");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ030"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("EMINENT_67_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_67_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_67_MQ040_startnpc01", "UNDERFORTRESS_67_MQ040", "Follow the keeper now, but speak with Amanda and inform her discreetly", "I will find a way on my own"))
		{
			case 1:
				await dialog.Msg("UNDER_67_MQ040_startnpc02");
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

		await dialog.Msg("UNDER_67_MQ040_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

