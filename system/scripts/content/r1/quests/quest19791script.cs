//--- Melia Script -----------------------------------------------------------
// Sanctum of Truth or Lie? (2)
//--- Description -----------------------------------------------------------
// Quest to Listen to the advice of the Cleric Master.
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

[QuestScript(19791)]
public class Quest19791Script : QuestScript
{
	protected override void Load()
	{
		SetId(19791);
		SetName("Sanctum of Truth or Lie? (2)");
		SetDescription("Listen to the advice of the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_5"));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_5_1_ST", "PILGRIM51_SQ_5_0", "Ask her about how to purify the Sanctum", "Better stand back as it's dangerous"))
		{
			case 1:
				await dialog.Msg("PILGRIM51_SQ_5_1_AC");
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM51_SQ_5_1");
	}
}

