//--- Melia Script -----------------------------------------------------------
// Workshop's Secret Device
//--- Description -----------------------------------------------------------
// Quest to Activate the Secret Device in the Interrogation Room Entrance.
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

[QuestScript(30202)]
public class Quest30202Script : QuestScript
{
	protected override void Load()
	{
		SetId(30202);
		SetName("Workshop's Secret Device");
		SetDescription("Activate the Secret Device in the Interrogation Room Entrance");

		AddPrerequisite(new LevelPrerequisite(269));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11029));
		AddReward(new ItemReward("Drug_Premium_SP1", 20));

		AddDialogHook("PRISON_81_SQ_OBJ_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

