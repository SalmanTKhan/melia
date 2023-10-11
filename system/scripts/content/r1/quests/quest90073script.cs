//--- Melia Script -----------------------------------------------------------
// Raising an Altar (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Verta.
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

[QuestScript(90073)]
public class Quest90073Script : QuestScript
{
	protected override void Load()
	{
		SetId(90073);
		SetName("Raising an Altar (3)");
		SetDescription("Talk to Loremaster Verta");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_4"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 2));

		AddDialogHook("CORAL_32_2_BERTA2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_5_ST", "CORAL_32_2_SQ_5", "I'll lead them so they won't be able to approach.", "That sounds way too dangerous."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_5_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_5_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

