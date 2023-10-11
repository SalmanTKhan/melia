//--- Melia Script -----------------------------------------------------------
// An Endless Deal (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Squire Williya.
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

[QuestScript(60059)]
public class Quest60059Script : QuestScript
{
	protected override void Load()
	{
		SetId(60059);
		SetName("An Endless Deal (2)");
		SetDescription("Talk to Squire Williya");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_01"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_WILLIYA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_GALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM313_SQ_02_01", "PILGRIM313_SQ_02", "I'll try to find them", "About the Legwyn Family", "Decline"))
		{
			case 1:
				// Func/PILGRIM313_SQ_02_RUN;
				// Func/PILGRIM313_SQ_02_START;
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("PILGRIM313_SQ_01_02");
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

