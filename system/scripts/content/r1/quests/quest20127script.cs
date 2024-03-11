//--- Melia Script -----------------------------------------------------------
// Using Status Points
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout.
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

[QuestScript(20127)]
public class Quest20127Script : QuestScript
{
	protected override void Load()
	{
		SetId(20127);
		SetName("Using Status Points");
		SetDescription("Talk to the Scout");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_DRASIUS1"));

		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeEnd", BeforeEnd);
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

