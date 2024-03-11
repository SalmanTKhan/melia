//--- Melia Script -----------------------------------------------------------
// Inspection Preparation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90132)]
public class Quest90132Script : QuestScript
{
	protected override void Load()
	{
		SetId(90132);
		SetName("Inspection Preparation (2)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_5_SQ_40_ST", "F_DCAPITAL_20_5_SQ_40", "I will come back with gathered demon power.", "It's too spooky."))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_5_SQ_40_AG");
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

		await dialog.Msg("F_DCAPITAL_20_5_SQ_40_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

