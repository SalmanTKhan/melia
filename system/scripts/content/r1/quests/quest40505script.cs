//--- Melia Script -----------------------------------------------------------
// Can Someone Help?
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40505)]
public class Quest40505Script : QuestScript
{
	protected override void Load()
	{
		SetId(40505);
		SetName("Can Someone Help?");
		SetDescription("Talk to Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_025_ST", "REMAINS37_1_SQ_025", "Accept the suggestion", "Decline"))
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

		await dialog.Msg("REMAINS37_1_SQ_025_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

