//--- Melia Script -----------------------------------------------------------
// Nobody Expects the Inquisition (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Judge Rymis at the Fedimian Outskirts.
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

[QuestScript(90092)]
public class Quest90092Script : QuestScript
{
	protected override void Load()
	{
		SetId(90092);
		SetName("Nobody Expects the Inquisition (2)");
		SetDescription("Talk to Judge Rymis at the Fedimian Outskirts");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_90"));

		AddDialogHook("CATACOMB_25_4_LAIMIS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_100_WARP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_100_ST", "CATACOMB_25_4_SQ_100", "I will go myself.", "Let's wait it out."))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_100_AG");
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
}

