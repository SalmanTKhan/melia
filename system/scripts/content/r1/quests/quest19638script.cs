//--- Melia Script -----------------------------------------------------------
// Raging Soul Releasing Test (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Gracius.
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

[QuestScript(19638)]
public class Quest19638Script : QuestScript
{
	protected override void Load()
	{
		SetId(19638);
		SetName("Raging Soul Releasing Test (2)");
		SetDescription("Talk to Pilgrim Gracius");

		AddPrerequisite(new LevelPrerequisite(127));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM50_SQ_020"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM50_SQ_028_ST", "PILGRIM50_SQ_028", "I'll help", "Reject it since it seems tiresome"))
		{
			case 1:
				await dialog.Msg("PILGRIM50_SQ_028_AC");
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

		await dialog.Msg("PILGRIM50_SQ_028_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

