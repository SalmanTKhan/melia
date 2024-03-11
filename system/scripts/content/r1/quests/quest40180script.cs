//--- Melia Script -----------------------------------------------------------
// Passing it Along (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Arunas.
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

[QuestScript(40180)]
public class Quest40180Script : QuestScript
{
	protected override void Load()
	{
		SetId(40180);
		SetName("Passing it Along (1)");
		SetDescription("Talk with Arunas");

		AddPrerequisite(new LevelPrerequisite(86));

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

		switch (await dialog.Select("FARM47_3_SQ_010_ST", "FARM47_3_SQ_010", "I will help if it's related to the purification", "About Myrkiti Farm", "Ignore"))
		{
			case 1:
				await dialog.Msg("FARM47_3_SQ_010_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM47_3_SQ_010_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_3_SQ_010_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

