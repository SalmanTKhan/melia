//--- Melia Script -----------------------------------------------------------
// Food Reserve (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tauras.
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

[QuestScript(40420)]
public class Quest40420Script : QuestScript
{
	protected override void Load()
	{
		SetId(40420);
		SetName("Food Reserve (2)");
		SetDescription("Talk to Tauras");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_050"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_TAURAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_TAURAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_060_ST", "FARM47_1_SQ_060", "I will collect for her", "About what the Baron Did", "Decline"))
		{
			case 1:
				await dialog.Msg("FARM47_1_SQ_060_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_060_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_1_SQ_060_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

