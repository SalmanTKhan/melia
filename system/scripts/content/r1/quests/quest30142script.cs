//--- Melia Script -----------------------------------------------------------
// Departured Villager's Memo
//--- Description -----------------------------------------------------------
// Quest to Check the abandoned memo.
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

[QuestScript(30142)]
public class Quest30142Script : QuestScript
{
	protected override void Load()
	{
		SetId(30142);
		SetName("Departured Villager's Memo");
		SetDescription("Check the abandoned memo");

		AddPrerequisite(new LevelPrerequisite(220));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7920));
		AddReward(new ItemReward("Drug_HP_GIMMICK2", 20));

		AddDialogHook("ORCHARD_34_1_SQ_2_OBJ_9", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

