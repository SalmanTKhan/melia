//--- Melia Script -----------------------------------------------------------
// Villagers' Valuables (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(50294)]
public class Quest50294Script : QuestScript
{
	protected override void Load()
	{
		SetId(50294);
		SetName("Villagers' Valuables (2)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY353_HQ1"));

		AddReward(new ItemReward("Gacha_H_007", 1));

		AddDialogHook("ABBEY_35_3_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_VILLAGE_B", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY353_HQ2_start1", "ABBEY353_HQ2", "I'll get those valuables back to the villagers.", "You can return them to the villagers yourself."))
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

		await dialog.Msg("ABBEY353_HQ2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

