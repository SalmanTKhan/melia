//--- Melia Script -----------------------------------------------------------
// Re-Confirm (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Costas.
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

[QuestScript(90089)]
public class Quest90089Script : QuestScript
{
	protected override void Load()
	{
		SetId(90089);
		SetName("Re-Confirm (2)");
		SetDescription("Talk to Costas");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_60"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_KOSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_KOSTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_70_ST", "CATACOMB_25_4_SQ_70", "Alright", "Decline"))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_70_AG");
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

		await dialog.Msg("CATACOMB_25_4_SQ_70_SU");
		// Func/CATACOMB_25_4_SQ_70_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

