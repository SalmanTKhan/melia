//--- Melia Script -----------------------------------------------------------
// Maven's Device (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Bishop.
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

[QuestScript(20311)]
public class Quest20311Script : QuestScript
{
	protected override void Load()
	{
		SetId(20311);
		SetName("Maven's Device (2)");
		SetDescription("Talk with the Bishop");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CHATHEDRAL54_BISHOP_AFTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ02_PART2_select01", "CHATHEDRAL54_MQ02_PART2", "Accept", "Reject"))
		{
			case 1:
				dialog.HideNPC("CHATHEDRAL54_BISHOP_AFTER");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

