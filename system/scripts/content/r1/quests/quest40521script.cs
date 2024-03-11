//--- Melia Script -----------------------------------------------------------
// Born with a Silver Spoon (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40521)]
public class Quest40521Script : QuestScript
{
	protected override void Load()
	{
		SetId(40521);
		SetName("Born with a Silver Spoon (2)");
		SetDescription("Talk to Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_040"));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_041_ST", "REMAINS37_1_SQ_041", "Let's go to the tablet in Gruitis Hall.", "Decline"))
		{
			case 1:
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

		await dialog.Msg("REMAINS37_1_SQ_041_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

