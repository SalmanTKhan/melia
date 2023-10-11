//--- Melia Script -----------------------------------------------------------
// The Sculpture in Slove Intersection (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Magic Block on the Sculptures in the Slove Intersection.
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

[QuestScript(50380)]
public class Quest50380Script : QuestScript
{
	protected override void Load()
	{
		SetId(50380);
		SetName("The Sculpture in Slove Intersection (2)");
		SetDescription("Use the Magic Block on the Sculptures in the Slove Intersection");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02_4_1"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 25000));

		AddDialogHook("NICO_811_SUBQ0241_OBJ", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_DEVICE4", "BeforeEnd", BeforeEnd);
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

