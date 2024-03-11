//--- Melia Script -----------------------------------------------------------
// Visiting Room's Secret Device
//--- Description -----------------------------------------------------------
// Quest to Check the Secret Device at Jibuza Square.
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

[QuestScript(30196)]
public class Quest30196Script : QuestScript
{
	protected override void Load()
	{
		SetId(30196);
		SetName("Visiting Room's Secret Device");
		SetDescription("Check the Secret Device at Jibuza Square");

		AddPrerequisite(new LevelPrerequisite(259));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10360));
		AddReward(new ItemReward("Drug_Premium_SP1", 20));

		AddDialogHook("PRISON_78_SQ_OBJ_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

