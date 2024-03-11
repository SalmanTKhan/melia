//--- Melia Script -----------------------------------------------------------
// To Gele Plateau
//--- Description -----------------------------------------------------------
// Quest to Talk to the Miners' Village Mayor.
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

[QuestScript(50006)]
public class Quest50006Script : QuestScript
{
	protected override void Load()
	{
		SetId(50006);
		SetName("To Gele Plateau");
		SetDescription("Talk to the Miners' Village Mayor");

		AddPrerequisite(new LevelPrerequisite(28));
		AddPrerequisite(new CompletedPrerequisite("CMINE6_TO_KATYN7_3"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

