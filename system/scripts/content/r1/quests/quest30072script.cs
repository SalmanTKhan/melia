//--- Melia Script -----------------------------------------------------------
// A Story Left Behind by Eras
//--- Description -----------------------------------------------------------
// Quest to Check the letter on the ground.
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

[QuestScript(30072)]
public class Quest30072Script : QuestScript
{
	protected override void Load()
	{
		SetId(30072);
		SetName("A Story Left Behind by Eras");
		SetDescription("Check the letter on the ground");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_SQ_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_ACCESSARY_NPC", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}
}

