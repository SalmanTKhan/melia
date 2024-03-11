//--- Melia Script -----------------------------------------------------------
// Naturally (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90099)]
public class Quest90099Script : QuestScript
{
	protected override void Load()
	{
		SetId(90099);
		SetName("Naturally (1)");
		SetDescription("Talk to Kupole Lina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MAPLE_25_3_SQ_50_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_40"));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("MAPLE_25_3_SQ_40_3");
		dialog.HideNPC("MAPLE_25_3_SQ_40_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

