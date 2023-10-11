//--- Melia Script -----------------------------------------------------------
// Piece of Wing (2)
//--- Description -----------------------------------------------------------
// Quest to Hand the Wing Fragment to the Troubled Owl Sculpture.
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

[QuestScript(4821)]
public class Quest4821Script : QuestScript
{
	protected override void Load()
	{
		SetId(4821);
		SetName("Piece of Wing (2)");
		SetDescription("Hand the Wing Fragment to the Troubled Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_1_TO_OWLJUNIOR2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(112));
		AddPrerequisite(new CompletedPrerequisite("KATYN13_1_TO_OWLJUNIOR1"));

		AddObjective("kill0", "Kill 15 High Vubbe(s)", new KillObjective(15, MonsterId.HighBube_Spear));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_OWLBOSS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN13_1_TO_OWLJUNIOR2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

