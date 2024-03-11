//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (8)
//--- Description -----------------------------------------------------------
// Quest to Check the lamp's magic stone.
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

[QuestScript(30227)]
public class Quest30227Script : QuestScript
{
	protected override void Load()
	{
		SetId(30227);
		SetName("Investigate Inner Wall District 8 (8)");
		SetDescription("Check the lamp's magic stone");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_8"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_OBJ_19", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

