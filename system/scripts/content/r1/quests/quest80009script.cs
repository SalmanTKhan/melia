//--- Melia Script -----------------------------------------------------------
// Remembering the Thoughts of Life before Death
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Gintas.
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

[QuestScript(80009)]
public class Quest80009Script : QuestScript
{
	protected override void Load()
	{
		SetId(80009);
		SetName("Remembering the Thoughts of Life before Death");
		SetDescription("Talk to Believer Gintas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_01"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_GINTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_GINTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_02_start", "CATACOMB_33_2_SQ_02", "I'll help in order to join the Order", "Decline"))
		{
			case 1:
				await dialog.Msg("CATACOMB_33_2_SQ_02_AG");
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

