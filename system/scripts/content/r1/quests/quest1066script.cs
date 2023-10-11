//--- Melia Script -----------------------------------------------------------
// In their Honor (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Pipoti.
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

[QuestScript(1066)]
public class Quest1066Script : QuestScript
{
	protected override void Load()
	{
		SetId(1066);
		SetName("In their Honor (3)");
		SetDescription("Talk to Stonemason Pipoti");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS8"));

		AddDialogHook("ROKAS24_PIPOTI", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_RECORD", "BeforeEnd", BeforeEnd);
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

		dialog.UnHideNPC("ROKAS31_RECORD");
		await dialog.Msg("CustomOkDlg/ROKAS31_RECORD_basic1/ROKAS29_VACYS9_SUCC_DIALOG_FUNC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

