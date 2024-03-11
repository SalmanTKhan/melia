//--- Melia Script -----------------------------------------------------------
// [Weekly] Spearhead - Challenge
//--- Description -----------------------------------------------------------
// Quest to Clear Challenge Mode 10 times{nl}You can proceed with the Field Challenge (Solo) from stage 3 and above..
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

[QuestScript(510015)]
public class Quest510015Script : QuestScript
{
	protected override void Load()
	{
		SetId(510015);
		SetName("[Weekly] Spearhead - Challenge");
		SetDescription("Clear Challenge Mode 10 times{nl}You can proceed with the Field Challenge (Solo) from stage 3 and above.");

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

