//--- Melia Script -----------------------------------------------------------
// The Goddess' Assignment (3)
//--- Description -----------------------------------------------------------
// Quest to Examine the Goddess' Orb.
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

[QuestScript(80036)]
public class Quest80036Script : QuestScript
{
	protected override void Load()
	{
		SetId(80036);
		SetName("The Goddess' Assignment (3)");
		SetDescription("Examine the Goddess' Orb");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_07"));

		AddReward(new ItemReward("ORCHARD_342_MQ_HOLLY_SPHERE", 1));

		AddDialogHook("ORCHARD342_HOLY_TALK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

