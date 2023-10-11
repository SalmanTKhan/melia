//--- Melia Script -----------------------------------------------------------
// Troublemaker Ridimeds (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Ruthalen.
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

[QuestScript(90050)]
public class Quest90050Script : QuestScript
{
	protected override void Load()
	{
		SetId(90050);
		SetName("Troublemaker Ridimeds (1)");
		SetDescription("Talk to Dievdirbys Ruthalen");

		AddPrerequisite(new LevelPrerequisite(249));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_9_ST", "KATYN_45_2_SQ_9", "I can help.", "I'm busy"))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_9_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_9_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

