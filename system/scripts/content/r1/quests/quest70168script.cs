//--- Melia Script -----------------------------------------------------------
// Declare Withdrawal of Protection
//--- Description -----------------------------------------------------------
// Quest to Talk to the abbot.
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

[QuestScript(70168)]
public class Quest70168Script : QuestScript
{
	protected override void Load()
	{
		SetId(70168);
		SetName("Declare Withdrawal of Protection");
		SetDescription("Talk to the abbot");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ08"));

		AddDialogHook("ABBEY394_MQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_09_1", "ABBEY39_4_MQ09", "I will wait.", "Push the discussions to later."))
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

		await dialog.Msg("ABBEY39_4_MQ_09_5");
		dialog.HideNPC("ABBEY394_MQ_09_1");
		dialog.HideNPC("ABBEY394_MQ_09_2");
		dialog.UnHideNPC("ABBEY394_MQ_09_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

