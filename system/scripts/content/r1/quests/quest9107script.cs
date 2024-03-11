//--- Melia Script -----------------------------------------------------------
// Messenger's Suspicious Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to the messenger.
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

[QuestScript(9107)]
public class Quest9107Script : QuestScript
{
	protected override void Load()
	{
		SetId(9107);
		SetName("Messenger's Suspicious Favor");
		SetDescription("Talk to the messenger");

		AddPrerequisite(new LevelPrerequisite(1));
		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ03"));

		AddDialogHook("ROKAS_25_HQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_25_HQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS_25_HQ_01_select01", "ROKAS_25_HQ_01", "I'll do the errand", "Decline"))
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

		await dialog.Msg("ROKAS_25_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

