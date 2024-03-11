//--- Melia Script -----------------------------------------------------------
// An Endless Deal (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the spirit of Gailus Legwyn.
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

[QuestScript(60060)]
public class Quest60060Script : QuestScript
{
	protected override void Load()
	{
		SetId(60060);
		SetName("An Endless Deal (3)");
		SetDescription("Talk to the spirit of Gailus Legwyn");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_02"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("PILGRIM313_SQ_04_ITEM", 1));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_GALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_GALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM313_SQ_03_01", "PILGRIM313_SQ_03", "I'll go and collect some Mochia stems", "About the Kartas Hunter", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM313_SQ_03_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("PILGRIM313_SQ_03_02");
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

