//--- Melia Script -----------------------------------------------------------
// Letters of a Prisoner
//--- Description -----------------------------------------------------------
// Quest to Check the letter on the ground at the Inmate's Lounge.
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

[QuestScript(30200)]
public class Quest30200Script : QuestScript
{
	protected override void Load()
	{
		SetId(30200);
		SetName("Letters of a Prisoner");
		SetDescription("Check the letter on the ground at the Inmate's Lounge");

		AddPrerequisite(new LevelPrerequisite(269));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_SQ_OBJ_1", "BeforeStart", BeforeStart);
		AddDialogHook("FEDIMIAN_OLDMAN1", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("PRISON_81_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

