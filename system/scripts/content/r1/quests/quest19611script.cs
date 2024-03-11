//--- Melia Script -----------------------------------------------------------
// Curse of Laziness - Soul Attack
//--- Description -----------------------------------------------------------
// Quest to Tree Root Crystal of Laziness in the upper area of Posukis Path Plaza.
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

[QuestScript(19611)]
public class Quest19611Script : QuestScript
{
	protected override void Load()
	{
		SetId(19611);
		SetName("Curse of Laziness - Soul Attack");
		SetDescription("Tree Root Crystal of Laziness in the upper area of Posukis Path Plaza");

		AddPrerequisite(new LevelPrerequisite(124));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST08", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

