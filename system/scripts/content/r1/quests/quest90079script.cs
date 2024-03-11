//--- Melia Script -----------------------------------------------------------
// Winning Favors (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90079)]
public class Quest90079Script : QuestScript
{
	protected override void Load()
	{
		SetId(90079);
		SetName("Winning Favors (2)");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_10"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 4));

		AddDialogHook("CORAL_32_2_DARUL2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_DARUL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_11_ST", "CORAL_32_2_SQ_11", "I'll fill the talisman with the energy from monsters.", "I have to go do something else, sorry."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_11_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_11_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

