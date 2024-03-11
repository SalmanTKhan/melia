//--- Melia Script -----------------------------------------------------------
// Creating Distractions (4)
//--- Description -----------------------------------------------------------
// Quest to Read the instruction.
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

[QuestScript(50331)]
public class Quest50331Script : QuestScript
{
	protected override void Load()
	{
		SetId(50331);
		SetName("Creating Distractions (4)");
		SetDescription("Read the instruction");

		AddPrerequisite(new LevelPrerequisite(348));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ5"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16704));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ6_IN", "BeforeEnd", BeforeEnd);
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

