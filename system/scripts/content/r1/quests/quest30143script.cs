//--- Melia Script -----------------------------------------------------------
// Departured Villager's Pot
//--- Description -----------------------------------------------------------
// Quest to Check the pot.
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

[QuestScript(30143)]
public class Quest30143Script : QuestScript
{
	protected override void Load()
	{
		SetId(30143);
		SetName("Departured Villager's Pot");
		SetDescription("Check the pot");

		AddPrerequisite(new LevelPrerequisite(220));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7920));
		AddReward(new ItemReward("Drug_SP_GIMMICK2", 20));

		AddDialogHook("ORCHARD_34_1_SQ_2_OBJ_11", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

