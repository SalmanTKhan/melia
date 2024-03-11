//--- Melia Script -----------------------------------------------------------
// Preparing for the Future (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Verta.
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

[QuestScript(90080)]
public class Quest90080Script : QuestScript
{
	protected override void Load()
	{
		SetId(90080);
		SetName("Preparing for the Future (1)");
		SetDescription("Talk to Loremaster Verta");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_9"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 3));

		AddDialogHook("CORAL_32_2_BERTA2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_12_ST", "CORAL_32_2_SQ_12", "I'll get it", "I'll think about it."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_12_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_12_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

