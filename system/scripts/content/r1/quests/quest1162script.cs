//--- Melia Script -----------------------------------------------------------
// Try Fishing
//--- Description -----------------------------------------------------------
// Quest to Talk to Fishing Manager Joha in Klaipeda..
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

[QuestScript(1162)]
public class Quest1162Script : QuestScript
{
	protected override void Load()
	{
		SetId(1162);
		SetName("Try Fishing");
		SetDescription("Talk to Fishing Manager Joha in Klaipeda.");

		AddPrerequisite(new LevelPrerequisite(30));

		AddDialogHook("KLAPEDA_FISHING_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_FISHING_MANAGER", "BeforeEnd", BeforeEnd);
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

		//SCR_TUTO_FISHING_SUCCESS_TX_FUNC
		await dialog.Msg("TUTO_FISHING_SUCCESS_DLG1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

