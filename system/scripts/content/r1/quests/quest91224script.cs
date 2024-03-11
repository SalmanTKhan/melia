//--- Melia Script -----------------------------------------------------------
// Figuring out the situation
//--- Description -----------------------------------------------------------
// Quest to Talk to Damijonas.
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

[QuestScript(91224)]
public class Quest91224Script : QuestScript
{
	protected override void Load()
	{
		SetId(91224);
		SetName("Figuring out the situation");
		SetDescription("Talk to Damijonas");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_PILGRIM_36_2_MQ13"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_DAMIJONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

