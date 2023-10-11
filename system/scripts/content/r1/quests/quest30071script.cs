//--- Melia Script -----------------------------------------------------------
// A Chest Locked By A Spell
//--- Description -----------------------------------------------------------
// Quest to Look inside the locked chest.
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

[QuestScript(30071)]
public class Quest30071Script : QuestScript
{
	protected override void Load()
	{
		SetId(30071);
		SetName("A Chest Locked By A Spell");
		SetDescription("Look inside the locked chest");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1026));
		AddReward(new ItemReward("ORSHA_BOOK_karolis02_BOOK", 1));
		AddReward(new ItemReward("Drug_SP1_Q", 45));

		AddDialogHook("KATYN_10_SQ_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_10_SQ_NPC_01", "BeforeEnd", BeforeEnd);
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

