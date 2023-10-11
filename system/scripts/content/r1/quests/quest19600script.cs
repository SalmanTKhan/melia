//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Abyss
//--- Description -----------------------------------------------------------
// Quest to The Tree Root Crystal at Noras Fountain.
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

[QuestScript(19600)]
public class Quest19600Script : QuestScript
{
	protected override void Load()
	{
		SetId(19600);
		SetName("Curse of Sloth - Abyss");
		SetDescription("The Tree Root Crystal at Noras Fountain");

		AddPrerequisite(new LevelPrerequisite(124));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST06", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

