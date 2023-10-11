//--- Melia Script -----------------------------------------------------------
// Searching for Evidence
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Tracker Capt. Mintz.
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

[QuestScript(70103)]
public class Quest70103Script : QuestScript
{
	protected override void Load()
	{
		SetId(70103);
		SetName("Searching for Evidence");
		SetDescription("Talk to Hunter Tracker Capt. Mintz");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ03"));

		AddDialogHook("THORN392_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_MQ_04_1", "THORN39_2_MQ04", "Tell him that you will meet with Hunter Reina", "I can only help so much"))
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

		await dialog.Msg("THORN39_2_MQ_04_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

