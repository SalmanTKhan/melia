//--- Melia Script -----------------------------------------------------------
// Temple Rebuilding Preparation (3)
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

[QuestScript(80050)]
public class Quest80050Script : QuestScript
{
	protected override void Load()
	{
		SetId(80050);
		SetName("Temple Rebuilding Preparation (3)");
		SetDescription("Speak with the Village Priest");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_SQ_02"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_324_SQ_03_start", "ORCHARD_324_SQ_03", "I will be the one to purify", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("ORCHARD_324_SQ_03_AG");
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


		return HookResult.Break;
	}
}

