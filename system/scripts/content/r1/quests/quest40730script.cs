//--- Melia Script -----------------------------------------------------------
// The Boiling Metal Plate
//--- Description -----------------------------------------------------------
// Quest to Talk to Alruida.
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

[QuestScript(40730)]
public class Quest40730Script : QuestScript
{
	protected override void Load()
	{
		SetId(40730);
		SetName("The Boiling Metal Plate");
		SetDescription("Talk to Alruida");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_060"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_070_ST", "REMAINS37_3_SQ_070", "I will find the Metal Plate", "The reason to be alone here", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_070_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAINS37_3_SQ_070_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS37_3_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

