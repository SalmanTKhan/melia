//--- Melia Script -----------------------------------------------------------
// Weapons Supply (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Horacius.
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

[QuestScript(40400)]
public class Quest40400Script : QuestScript
{
	protected override void Load()
	{
		SetId(40400);
		SetName("Weapons Supply (4)");
		SetDescription("Talk to Horacius");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_030"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_LEADER", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_LEADER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_040_ST", "FARM47_1_SQ_040", "I will try", "Better do it yourself"))
		{
			case 1:
				await dialog.Msg("FARM47_1_SQ_040_AC");
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

		await dialog.Msg("FARM47_1_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

