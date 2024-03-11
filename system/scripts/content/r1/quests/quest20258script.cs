//--- Melia Script -----------------------------------------------------------
// In the name of Faith (4)
//--- Description -----------------------------------------------------------
// Quest to Use the refined Magic Crystal to remove the thorny vines.
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

[QuestScript(20258)]
public class Quest20258Script : QuestScript
{
	protected override void Load()
	{
		SetId(20258);
		SetName("In the name of Faith (4)");
		SetDescription("Use the refined Magic Crystal to remove the thorny vines");

		AddPrerequisite(new LevelPrerequisite(59));
		AddPrerequisite(new CompletedPrerequisite("THORN19_MQ13"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1062));

		AddDialogHook("THORN_GATEWAY_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

