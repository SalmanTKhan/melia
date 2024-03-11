//--- Melia Script -----------------------------------------------------------
// Nobody Expects the Inquisition (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Priest Master at Klaipeda.
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

[QuestScript(90091)]
public class Quest90091Script : QuestScript
{
	protected override void Load()
	{
		SetId(90091);
		SetName("Nobody Expects the Inquisition (1)");
		SetDescription("Talk with the Priest Master at Klaipeda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_80"));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_LAIMIS", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("CATACOMB_25_4_SQ_90_SU");
		dialog.HideNPC("CATACOMB_25_4_SQ_KOSTAS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

