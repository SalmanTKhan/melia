//--- Melia Script -----------------------------------------------------------
// Crystal Stone in the Garden (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the crystal stone in Oro Garden.
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

[QuestScript(72119)]
public class Quest72119Script : QuestScript
{
	protected override void Load()
	{
		SetId(72119);
		SetName("Crystal Stone in the Garden (2)");
		SetDescription("Destroy the crystal stone in Oro Garden");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ04"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE262_SQ05_LINK_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("3CMLAKE262_SQ05_DLG02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

