//--- Melia Script -----------------------------------------------------------
// Box Delivery
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Ellie.
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

[QuestScript(70004)]
public class Quest70004Script : QuestScript
{
	protected override void Load()
	{
		SetId(70004);
		SetName("Box Delivery");
		SetDescription("Talk to Druid Ellie");

		AddPrerequisite(new LevelPrerequisite(149));
		AddPrerequisite(new CompletedPrerequisite("FARM49_1_MQ04"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_MQ_05_1", "FARM49_1_MQ05", "I'll deliver it for you", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM49_1_MQ_05_2");
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

		await dialog.Msg("FARM49_1_MQ_06_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}
