//--- Melia Script -----------------------------------------------------------
// Letas Altar
//--- Description -----------------------------------------------------------
// Quest to Check the Letas Altar.
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

[QuestScript(30073)]
public class Quest30073Script : QuestScript
{
	protected override void Load()
	{
		SetId(30073);
		SetName("Letas Altar");
		SetDescription("Check the Letas Altar");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_SQ_NPC_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

