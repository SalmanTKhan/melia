//--- Melia Script -----------------------------------------------------------
// [Weekly] Spearhead - Division Singularity 
//--- Description -----------------------------------------------------------
// Quest to Clear Challenge Mode : Division Singularity stage 3 or above, Auto Match for 10 times.
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

[QuestScript(510016)]
public class Quest510016Script : QuestScript
{
	protected override void Load()
	{
		SetId(510016);
		SetName("[Weekly] Spearhead - Division Singularity ");
		SetDescription("Clear Challenge Mode : Division Singularity stage 3 or above, Auto Match for 10 times");

		AddPrerequisite(new LevelPrerequisite(458));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

