//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Route
//--- Description -----------------------------------------------------------
// Quest to Talk to the Patrolling Officer.
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

[QuestScript(4879)]
public class Quest4879Script : QuestScript
{
	protected override void Load()
	{
		SetId(4879);
		SetName("Bonfire of the Patrol Route");
		SetDescription("Talk to the Patrolling Officer");

		AddPrerequisite(new LevelPrerequisite(106));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("KATYN_SUCH_POINT_01_SOLDIER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SUCH_POINT_TXT01", "SUCH_POINT_01", "Alright", "There is no time for that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

