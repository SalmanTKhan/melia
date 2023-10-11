//--- Melia Script -----------------------------------------------------------
// Secret of the Oratory (2)
//--- Description -----------------------------------------------------------
// Quest to Read yet another book.
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

[QuestScript(91196)]
public class Quest91196Script : QuestScript
{
	protected override void Load()
	{
		SetId(91196);
		SetName("Secret of the Oratory (2)");
		SetDescription("Read yet another book");

		AddPrerequisite(new LevelPrerequisite(489));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_SQ1"));

		AddReward(new ExpReward(4200000000, 4200000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP15_1_ABBEY3_SQ2_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

