//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (5)
//--- Description -----------------------------------------------------------
// Quest to Check the magic circle maintenance department.
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

[QuestScript(30224)]
public class Quest30224Script : QuestScript
{
	protected override void Load()
	{
		SetId(30224);
		SetName("Investigate Inner Wall District 8 (5)");
		SetDescription("Check the magic circle maintenance department");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_5"));

		AddDialogHook("CASTLE_20_3_OBJ_8_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_OBJ_7", "BeforeEnd", BeforeEnd);
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE_20_3_SQ_7");
	}
}

