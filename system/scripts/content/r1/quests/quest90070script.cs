//--- Melia Script -----------------------------------------------------------
// Loremasters of the Goddess (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90070)]
public class Quest90070Script : QuestScript
{
	protected override void Load()
	{
		SetId(90070);
		SetName("Loremasters of the Goddess (2)");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_1"));

		AddDialogHook("CORAL_32_2_DARUL1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_DARUL1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_2_ST", "CORAL_32_2_SQ_2", "I'm listening.", "I am not interested"))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_2_AG");
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

		await dialog.Msg("CORAL_32_2_SQ_2_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

