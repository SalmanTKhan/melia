//--- Melia Script -----------------------------------------------------------
// What happened at the Pit?
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Simonas.
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

[QuestScript(90022)]
public class Quest90022Script : QuestScript
{
	protected override void Load()
	{
		SetId(90022);
		SetName("What happened at the Pit?");
		SetDescription("Talk to Merchant Simonas");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_2"));

		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_3_ST", "CORAL_32_1_SQ_3", "I will find out more about it", "Please wait a bit"))
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

		await dialog.Msg("CORAL_32_1_SQ_3_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

