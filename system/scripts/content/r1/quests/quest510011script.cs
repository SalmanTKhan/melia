//--- Melia Script -----------------------------------------------------------
// [Weekly] Conquest - Legend Raid
//--- Description -----------------------------------------------------------
// Quest to Clear Legend Raid 10 times.
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

[QuestScript(510011)]
public class Quest510011Script : QuestScript
{
	protected override void Load()
	{
		SetId(510011);
		SetName("[Weekly] Conquest - Legend Raid");
		SetDescription("Clear Legend Raid 10 times");

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

