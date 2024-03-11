//--- Melia Script -----------------------------------------------------------
// Genuine Goddess Statue (4)
//--- Description -----------------------------------------------------------
// Quest to Check if the Goddess Statue is well repaired.
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

[QuestScript(19780)]
public class Quest19780Script : QuestScript
{
	protected override void Load()
	{
		SetId(19780);
		SetName("Genuine Goddess Statue (4)");
		SetDescription("Check if the Goddess Statue is well repaired");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_4_1"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3225));

		AddDialogHook("PILGRIM51_FGOD02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

