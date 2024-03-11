//--- Melia Script -----------------------------------------------------------
// A Story of Demons and Goddesses (1)
//--- Description -----------------------------------------------------------
// Quest to Release the Treaty Seal.
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

[QuestScript(30292)]
public class Quest30292Script : QuestScript
{
	protected override void Load()
	{
		SetId(30292);
		SetName("A Story of Demons and Goddesses (1)");
		SetDescription("Release the Treaty Seal");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_8"));

		AddReward(new ItemReward("WTREES_21_1_SQ_9_ITEM", 1));

		AddDialogHook("WTREES_21_1_OBJ_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

