//--- Melia Script -----------------------------------------------------------
// The Second Epitaph (5)
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(40621)]
public class Quest40621Script : QuestScript
{
	protected override void Load()
	{
		SetId(40621);
		SetName("The Second Epitaph (5)");
		SetDescription("Read the epitaph");

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_040"));

		AddDialogHook("REMAINS37_2_MT02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_2_MT02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await Task.Delay(300);
		await dialog.Msg("AITVARAS_RECORD_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

