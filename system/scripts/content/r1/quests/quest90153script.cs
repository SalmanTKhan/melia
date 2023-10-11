//--- Melia Script -----------------------------------------------------------
// Veteran Merceneary Combat [Doppelsoeldner Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Doppelsoeldner Master.
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

[QuestScript(90153)]
public class Quest90153Script : QuestScript
{
	protected override void Load()
	{
		SetId(90153);
		SetName("Veteran Merceneary Combat [Doppelsoeldner Advancement]");
		SetDescription("Talk to the Doppelsoeldner Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DOPPELSOELDNER_8_1_ST", "JOB_DOPPELSOELDNER_8_1", "I am prepared like always.", "Ready, it is not."))
		{
			case 1:
				await dialog.Msg("JOB_DOPPELSOELDNER_8_1_AG");
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

		await dialog.Msg("JOB_DOPPELSOELDNER_8_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

