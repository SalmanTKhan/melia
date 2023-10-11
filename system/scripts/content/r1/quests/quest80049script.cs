//--- Melia Script -----------------------------------------------------------
// Temple Rebuilding Preparation (2)
//--- Description -----------------------------------------------------------
// Quest to Speak with the Village Priest.
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

[QuestScript(80049)]
public class Quest80049Script : QuestScript
{
	protected override void Load()
	{
		SetId(80049);
		SetName("Temple Rebuilding Preparation (2)");
		SetDescription("Speak with the Village Priest");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_SQ_01"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_324_SQ_02_start", "ORCHARD_324_SQ_02", "I will come back with some answers", "About Fedimian", "I think that's going to be difficult"))
		{
			case 1:
				await dialog.Msg("ORCHARD_324_SQ_02_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ORCHARD_324_SQ_02_add");
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

