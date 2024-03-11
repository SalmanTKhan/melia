//--- Melia Script -----------------------------------------------------------
// To Starving Demon's Way
//--- Description -----------------------------------------------------------
// Quest to Move to Starving Demon's Way.
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

[QuestScript(50026)]
public class Quest50026Script : QuestScript
{
	protected override void Load()
	{
		SetId(50026);
		SetName("To Starving Demon's Way");
		SetDescription("Move to Starving Demon's Way");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("THORN23_BOSSKILL_1"));

		AddDialogHook("THORN23_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("FEDMIAN_PILGRIM46", "BeforeEnd", BeforeEnd);
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

