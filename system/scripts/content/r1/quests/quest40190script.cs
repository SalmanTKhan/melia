//--- Melia Script -----------------------------------------------------------
// Passing it Along (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Arunas.
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

[QuestScript(40190)]
public class Quest40190Script : QuestScript
{
	protected override void Load()
	{
		SetId(40190);
		SetName("Passing it Along (2)");
		SetDescription("Talk with Arunas");

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("FARM47_3_SQ_010"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_ARUNAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ARUNAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_3_SQ_020_ST", "FARM47_3_SQ_020", "Tell him to take some rest since you will do it for him", "Cheer up"))
		{
			case 1:
				await dialog.Msg("FARM47_3_SQ_020_AC");
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

		await dialog.Msg("FARM47_3_SQ_020_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

