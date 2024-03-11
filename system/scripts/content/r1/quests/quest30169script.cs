//--- Melia Script -----------------------------------------------------------
// The perfect massacre
//--- Description -----------------------------------------------------------
// Quest to Activate the Secret Device in the Long Sentence Prison Cell.
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

[QuestScript(30169)]
public class Quest30169Script : QuestScript
{
	protected override void Load()
	{
		SetId(30169);
		SetName("The perfect massacre");
		SetDescription("Activate the Secret Device in the Long Sentence Prison Cell");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_5"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_OBJ_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

