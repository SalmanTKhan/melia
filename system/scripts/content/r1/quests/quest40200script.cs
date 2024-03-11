//--- Melia Script -----------------------------------------------------------
// Your Curiosity Should End Here
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Rimas.
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

[QuestScript(40200)]
public class Quest40200Script : QuestScript
{
	protected override void Load()
	{
		SetId(40200);
		SetName("Your Curiosity Should End Here");
		SetDescription("Talk to Wizard Rimas");

		AddPrerequisite(new LevelPrerequisite(86));

		AddReward(new ItemReward("FARM47_3_SQ_050_ITEM_11", 1));

		AddDialogHook("FARM47_RIMAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_RIMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_3_SQ_030_ST", "FARM47_3_SQ_030", "I will help if it's related to the purification", "About the power generator in front", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_3_SQ_030_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_3_SQ_030_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

