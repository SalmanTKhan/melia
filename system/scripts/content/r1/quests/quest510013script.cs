//--- Melia Script -----------------------------------------------------------
// [Weekly] Spearhead - Joint Strike Raid
//--- Description -----------------------------------------------------------
// Quest to Participate in Joint Strike Raid 2 times.
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

[QuestScript(510013)]
public class Quest510013Script : QuestScript
{
	protected override void Load()
	{
		SetId(510013);
		SetName("[Weekly] Spearhead - Joint Strike Raid");
		SetDescription("Participate in Joint Strike Raid 2 times");

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

