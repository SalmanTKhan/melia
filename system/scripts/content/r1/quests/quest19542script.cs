//--- Melia Script -----------------------------------------------------------
// The stack of food at Starving Demon's Way (3)
//--- Description -----------------------------------------------------------
// Quest to Look closely at the piled up food.
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

[QuestScript(19542)]
public class Quest19542Script : QuestScript
{
	protected override void Load()
	{
		SetId(19542);
		SetName("The stack of food at Starving Demon's Way (3)");
		SetDescription("Look closely at the piled up food");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_111"));

		AddDialogHook("PILGRIM46_FOOD03_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

