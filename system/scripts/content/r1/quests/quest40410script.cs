//--- Melia Script -----------------------------------------------------------
// Food Reserve (1)
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

[QuestScript(40410)]
public class Quest40410Script : QuestScript
{
	protected override void Load()
	{
		SetId(40410);
		SetName("Food Reserve (1)");
		SetDescription("Talk to Tauras");

		AddPrerequisite(new LevelPrerequisite(93));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_TAURAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_TAURAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_050_ST", "FARM47_1_SQ_050", "I'll help", "About the work that you are trying to do right now", "I'm busy"))
		{
			case 1:
				await dialog.Msg("FARM47_1_SQ_050_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_1_SQ_050_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

