//--- Melia Script -----------------------------------------------------------
// Justified Suspicion
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(60151)]
public class Quest60151Script : QuestScript
{
	protected override void Load()
	{
		SetId(60151);
		SetName("Justified Suspicion");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(26));
		AddPrerequisite(new CompletedPrerequisite("GELE571_MQ_06"));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_MARLEY", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MARLEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE571_RP_1", "GELE571_RP_1", "I'll help you", "That is not needed"))
		{
			case 1:
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

		await dialog.Msg("GELE571_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

