//--- Melia Script -----------------------------------------------------------
// The Sculpture in Starry Town Square (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Magic Block on the Sculptures in the Starry Town Square.
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

[QuestScript(50378)]
public class Quest50378Script : QuestScript
{
	protected override void Load()
	{
		SetId(50378);
		SetName("The Sculpture in Starry Town Square (2)");
		SetDescription("Use the Magic Block on the Sculptures in the Starry Town Square");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02_2_1"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 23000));

		AddDialogHook("NICO811_DEVICE3", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_DEVICE3", "BeforeEnd", BeforeEnd);
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

	public override void OnStart(Character character, Quest quest)
	{
		// Func/SCR_NICO811_DEVICE3_PROG_FUNC;
	}
}

